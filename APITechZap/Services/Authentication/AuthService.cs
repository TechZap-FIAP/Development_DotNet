using ApiGreenway.Models;
using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Models.DTOs;
using APITechZap.Repository;
using APITechZap.Repository.Interface;
using FirebaseAdmin.Auth;
using Microsoft.EntityFrameworkCore;

namespace APITechZap.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly HttpClient _httpClient;
    private readonly IUserAdditionalDataRepository _userAdditionalDataRepository;
    private readonly IAddressRepository _addressRepository;

    public AuthService(ApplicationDbContext dbContext, HttpClient httpClient,
        IUserAdditionalDataRepository userAdditionalDataRepository, IAddressRepository addressRepository)
    {
        _dbContext = dbContext;
        _httpClient = httpClient;
        _userAdditionalDataRepository = userAdditionalDataRepository;
        _addressRepository = addressRepository;
    }

    public async Task<string> LoginAsync(UserLoginDTO request)
    {
        if (request == null || string.IsNullOrEmpty(request.DsEmail) || string.IsNullOrEmpty(request.DsPassword))
        {
            throw new ArgumentException("E-mail e senha são obrigatórios.");
        }

        var loginData = new
        {
            email = request.DsEmail,
            password = request.DsPassword,
            returnSecureToken = true
        };
        var response = await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress, loginData);

        if (response.IsSuccessStatusCode)
        {
            var authResponse = await response.Content.ReadFromJsonAsync<AuthFirebase>();
            if (authResponse != null && !string.IsNullOrEmpty(authResponse.IdToken))
            {
                return authResponse.IdToken; // Retorna o token de autenticação
            }
            throw new Exception("Token não retornado!");
        }

        throw new Exception("Falha na autenticação: " + response.ReasonPhrase);
    }

    public async Task<string> RegisterAsync(UserRegisterDTO request)
    {
        // Valida os dados de entrada
        if (request == null || string.IsNullOrEmpty(request.DsEmail) || string.IsNullOrEmpty(request.DsPassword))
        {
            throw new ArgumentException("E-mail e senha são obrigatórios.");
        }

        if (request.DsPassword.Length < 6)
        {
            throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.");
        }

        // Prepara os argumentos para criar um novo usuário no Firebase
        var userArgs = new UserRecordArgs
        {
            Email = request.DsEmail,
            Password = request.DsPassword,
            Disabled = false
        };

        // Cria o usuário no Firebase
        UserRecord newUserFb;
        try
        {
            newUserFb = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
        }
        catch (FirebaseAuthException ex)
        {
            throw new Exception("Erro ao criar usuário no Firebase: " + ex.Message, ex);
        }

        // Cria um novo objeto User para o banco de dados
        var newUser = new User
        {
            DsUidFirebase = newUserFb.Uid,
            DsName = request.DsName,
            DsSurname = request.DsSurname,
            DsEmail = newUserFb.Email,
            DsPassword = BCrypt.Net.BCrypt.HashPassword(request.DsPassword) // Criptografa a senha
        };

        // Adiciona o novo usuário ao banco de dados
        await _dbContext.Users.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();

        return $"Usuário cadastrado com sucesso! ID do usuário (BD): {newUser.IdUser}, UID (FB): {newUserFb.Uid}";
    }

    public async Task<string> UpdateUserByEmailAsync(string oldEmail, UserUpdateDTO request)
    {
        // Busca o usuário no banco de dados
        var userDb = await _dbContext.Users.FirstOrDefaultAsync(r => r.DsEmail == oldEmail && r.DtDeletedAt == null)
            ?? throw new Exception("Usuário não encontrado");

        // Prepara os argumentos para atualizar o usuário no Firebase
        var userArgs = new UserRecordArgs
        {
            Uid = userDb.DsUidFirebase,
            Email = request.DsEmail,
            Password = request.DsPassword != null ? BCrypt.Net.BCrypt.HashPassword(request.DsPassword) : null,
        };

        // Atualiza o usuário no Firebase
        await FirebaseAuth.DefaultInstance.UpdateUserAsync(userArgs);

        // Atualiza o usuário no banco de dados
        if (request.DsEmail != null)
        {
            userDb.DsEmail = request.DsEmail;
        }

        if (request.DsPassword != null)
        {
            userDb.DsPassword = BCrypt.Net.BCrypt.HashPassword(request.DsPassword);
        }

        userDb.DtUpdatedAt = DateTime.Now;

        userDb.UserAdditionalData = request.UserAdditionalData != null ? new UserAdditionalData
        {
            DsCPF = request.UserAdditionalData.DsCPF,
            DsPhone = request.UserAdditionalData.DsPhone,
            DtBirthDate = request.UserAdditionalData.DtBirthDate,
            Address = request.UserAdditionalData.Address != null ? new Address
            {
                DsZipCode = request.UserAdditionalData.Address.DsZipCode,
                DsStreet = request.UserAdditionalData.Address.DsStreet,
                DsNumber = request.UserAdditionalData.Address.DsNumber,
                DsComplement = request.UserAdditionalData.Address.DsComplement,
                DsNeighborhood = request.UserAdditionalData.Address.DsNeighborhood,
                DsCity = request.UserAdditionalData.Address.DsCity,
                DsState = request.UserAdditionalData.Address.DsState,
            } : null
        } : null;


        // Adiciona dados adicionais se disponíveis
        if (userDb.UserAdditionalData != null)
        {
            await _userAdditionalDataRepository.AddUserAdditionalDataAsync(userDb.UserAdditionalData);
        }

        // Adiciona endereço se disponível
        if (userDb.UserAdditionalData?.Address != null)
        {
            await _addressRepository.AddAddressAsync(userDb.UserAdditionalData.Address);
        }

        await _dbContext.SaveChangesAsync();

        return "Usuário atualizado com sucesso!";
    }

    public async Task<string> DeleteUserAsync(int userId)
    {
        var userDb = await _dbContext.Users.FirstOrDefaultAsync(r => r.IdUser == userId);
        if (userDb != null)
        {
            var uidFirebase = userDb.DsUidFirebase;

            if (string.IsNullOrEmpty(uidFirebase))
            {
                throw new Exception("UID do Firebase não encontrado.");
            }

            userDb.DtDeletedAt = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            var userArgs = new UserRecordArgs
            {
                Uid = uidFirebase,
                Disabled = true,
            };

            await FirebaseAuth.DefaultInstance.UpdateUserAsync(userArgs);

            return "Usuário desativado com sucesso";
        }
        throw new Exception("Usuário não encontrado.");
    }

    public async Task<string> ReactiveUserAsync(int userId)
    {
        var userDb = await _dbContext.Users.FirstOrDefaultAsync(r => r.IdUser == userId && r.DtDeletedAt != null);
        if (userDb != null)
        {
            var uidFirebase = userDb.DsUidFirebase;

            if (string.IsNullOrEmpty(uidFirebase))
            {
                throw new Exception("UID do Firebase não encontrado.");
            }
            userDb.DtDeletedAt = null;

            await _dbContext.SaveChangesAsync();

            var userArgs = new UserRecordArgs
            {
                Uid = uidFirebase,
                Disabled = false,
            };

            await FirebaseAuth.DefaultInstance.UpdateUserAsync(userArgs);

            return "Usuário reativado com sucesso";
        }
        throw new Exception("Usuário não encontrado.");
    }

    public async Task<string> ForgotPasswordUserAsync(string actualEmail)
    {
        if (string.IsNullOrEmpty(actualEmail))
        {
            throw new ArgumentException("O E-mail é obrigatório!");
        }

        var response = await FirebaseAuth.DefaultInstance.GeneratePasswordResetLinkAsync(actualEmail);
        return "E-mail de redefinição de senha enviado com sucesso!";
    }
}
