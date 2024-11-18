using ApiGreenway.Models;
using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Models.DTOs;
using APITechZap.Repository;
using APITechZap.Repository.Interface;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITechZap.Services.Authentication;

/// <summary>
/// Classe de serviço para autenticação de usuários
/// </summary>
public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly HttpClient _httpClient;
    private readonly IUserAdditionalDataRepository _userAdditionalDataRepository;
    private readonly IAddressRepository _addressRepository;


    /// <summary>
    /// Construtor da classe AuthService
    /// </summary>
    /// <param name="dbContext"></param>
    /// <param name="httpClient"></param>
    /// <param name="userAdditionalDataRepository"></param>
    /// <param name="addressRepository"></param>
    public AuthService(ApplicationDbContext dbContext, HttpClient httpClient, IUserAdditionalDataRepository userAdditionalDataRepository, IAddressRepository addressRepository)
    {
        _dbContext = dbContext;
        _httpClient = httpClient;
        _userAdditionalDataRepository = userAdditionalDataRepository;
        _addressRepository = addressRepository;
    }

    /// <summary>
    /// Método para registrar um novo usuário
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<string> RegisterAsync(UserRegisterDTO request)
    {
        if (request == null || string.IsNullOrEmpty(request.DsEmail) || string.IsNullOrEmpty(request.DsPassword))
        {
            throw new ArgumentException("E-mail e senha são obrigatórios.");
        }

        if (request.DsPassword.Length < 6)
        {
            throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.");
        }

        // Cria o objeto User para o banco de dados
        var newUser = new User
        {
            DsName = request.DsName,
            DsSurname = request.DsSurname,
            DsEmail = request.DsEmail,
            DsPassword = BCrypt.Net.BCrypt.HashPassword(request.DsPassword),
        };

        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            // Salva o usuário no banco de dados
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            // Commit da transação após salvar o usuário
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Erro ao salvar usuário no banco de dados: " + ex.Message, ex);
        }

        // Registra no Firebase somente após a transação bem-sucedida
        try
        {
            var userArgs = new UserRecordArgs
            {
                Email = request.DsEmail,
                Password = request.DsPassword,
                Disabled = false
            };

            var newUserFb = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
            newUser.DsUidFirebase = newUserFb.Uid;

            _dbContext.Users.Update(newUser);
            await _dbContext.SaveChangesAsync();

            return $"Usuário cadastrado com sucesso! \nID do usuário (BD): {newUser.IdUser}, UID (Firebase): {newUserFb.Uid}";
        }
        catch (FirebaseAuthException ex)
        {
            throw new Exception("Erro ao criar usuário no Firebase: " + ex.Message);
        }
    }

    /// <summary>
    /// Método para adicionar dados adicionais a um usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="additionalData"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<string> AddUserAdditionalDataAsync(int userId, UserAdditionalDataDTO additionalData)
    {
        if (additionalData == null)
        {
            throw new ArgumentException("Dados adicionais são obrigatórios.");
        }

        // Encontra o usuário pelo ID
        var userAdditionalDataDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.IdUser == userId);

        if (userAdditionalDataDb == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        // Cria os dados adicionais
        var userAdditionalData = new UserAdditionalData
        {
            DsCPF = additionalData.DsCPF,
            DsPhone = additionalData.DsPhone,
            DtBirthDate = additionalData.DtBirthDate,
            DtUpdatedAt = DateTime.Now,
            IdUser = userAdditionalDataDb.IdUser, // Associa o usuário aos dados adicionais
        };

        // Salva os dados adicionais no banco de dados
        var response = await _userAdditionalDataRepository.AddUserAdditionalDataAsync(userAdditionalData);

        return response;
    }

    /// <summary>
    /// Metodo para adicionar o endereço nos dados adicionais
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="addressDTO"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> AddAddress(int userId, AddressDTO addressDTO)
    {
        var user = await _dbContext.Users
            .Include(u => u.Address) // Se você deseja carregar o endereço atual
            .FirstOrDefaultAsync(u => u.IdUser == userId);

        if (user == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        var address = new Address
        {
            DsStreet = addressDTO.DsStreet,
            DsNumber = addressDTO.DsNumber,
            DsComplement = addressDTO.DsComplement,
            DsNeighborhood = addressDTO.DsNeighborhood,
            DsCity = addressDTO.DsCity,
            DsState = addressDTO.DsState,
            DsZipCode = addressDTO.DsZipCode,
            IdUser = user.IdUser
        };

        var response = await _addressRepository.AddAddressAsync(address);

        return response;
    }

    /// <summary>
    /// Método para autenticar um usuário
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="Exception"></exception>
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

    /// <summary>
    /// Método para atualizar um usuário pelo e-mail
    /// </summary>
    /// <param name="oldEmail"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
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

        await _dbContext.SaveChangesAsync();

        return "Usuário atualizado com sucesso!";
    }

    /// <summary>
    /// Método para atualizar um usuário pelo ID
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
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

    /// <summary>
    /// Método para reativar um usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
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

    /// <summary>
    /// Método para redefinir a senha de um usuário
    /// </summary>
    /// <param name="actualEmail"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
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
