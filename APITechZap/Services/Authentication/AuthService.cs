using ApiGreenway.Models;
using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Models.DTOs.UserDTOs;
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


    /// <summary>
    /// Construtor da classe AuthService
    /// </summary>
    /// <param name="dbContext"></param>
    /// <param name="httpClient"></param>
    /// <param name="userAdditionalDataRepository"></param>
    /// <param name="addressRepository"></param>
    public AuthService(ApplicationDbContext dbContext, HttpClient httpClient)
    {
        _dbContext = dbContext;
        _httpClient = httpClient;
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
    /// Método para autenticar um usuário
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<string> LoginAsync(UserLoginDTO request)
    {
        if (string.IsNullOrEmpty(request.DsEmail) || string.IsNullOrEmpty(request.DsPassword))
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
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> UpdateUserByIdAsync(int userId, UserUpdateDTO request)
    {
        // Busca o usuário no banco de dados
        var userDb = await _dbContext.Users.
            FirstOrDefaultAsync(r => r.IdUser == userId && r.DtDeletedAt == null)
            ?? throw new Exception("Usuário não encontrado");

        // Prepara os argumentos para atualizar o usuário no Firebase
        var userArgs = new UserRecordArgs
        {
            Uid = userDb.DsUidFirebase,
            Email = request.DsEmail,
            Password = request.DsPassword != null ? BCrypt.Net.BCrypt.HashPassword(request.DsPassword) : null,
        };

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

        try
        {
            // Atualiza o usuário no Firebase
            await FirebaseAuth.DefaultInstance.UpdateUserAsync(userArgs);

            await _dbContext.SaveChangesAsync();

            return "Usuário atualizado com sucesso!";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
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
        var userAdditionalData = await _dbContext.UserAdditionalDatas.FirstOrDefaultAsync(r => r.IdUser == userId);
        var address = await _dbContext.Addresses.FirstOrDefaultAsync(r => r.IdUser == userId);

        if (userDb != null)
        {
            var uidFirebase = userDb.DsUidFirebase;

            if (string.IsNullOrEmpty(uidFirebase))
            {
                throw new Exception("UID do Firebase não encontrado.");
            }

            userDb.DtDeletedAt = DateTime.Now;

            var userArgs = new UserRecordArgs
            {
                Uid = uidFirebase,
                Disabled = true,
            };

            try
            {
                await _dbContext.SaveChangesAsync();

                await FirebaseAuth.DefaultInstance.UpdateUserAsync(userArgs);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        if (userAdditionalData != null)
        {
            userAdditionalData.DtDeletedAt = DateTime.Now;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        if (address != null)
        {
            address.DtDeletedAt = DateTime.Now;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        return "Usuário deletado com sucesso";
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
        var userAdditionalData = await _dbContext.UserAdditionalDatas.FirstOrDefaultAsync(u => u.IdUser == userId && u.DtDeletedAt != null);
        var address = await _dbContext.Addresses.FirstOrDefaultAsync(u => u.IdUser == userId && u.DtDeletedAt != null);

        if (userDb != null)
        {
            var uidFirebase = userDb.DsUidFirebase;

            if (string.IsNullOrEmpty(uidFirebase))
            {
                throw new Exception("UID do Firebase não encontrado.");
            }

            var userArgs = new UserRecordArgs
            {
                Uid = uidFirebase,
                Disabled = false,
            };

            userDb.DtDeletedAt = null;

            try
            {
                await _dbContext.SaveChangesAsync();

                await FirebaseAuth.DefaultInstance.UpdateUserAsync(userArgs);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        if(userAdditionalData != null)
        {
            userAdditionalData.DtDeletedAt = null;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        if (address != null)
        {
            address.DtDeletedAt = null;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        return "Usuário reativado com sucesso";
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
        return response;
    }
}
