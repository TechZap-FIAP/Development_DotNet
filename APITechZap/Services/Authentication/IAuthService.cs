using APITechZap.Models;
using APITechZap.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace APITechZap.Services.Authentication;

/// <summary>
/// Interface de Serviço de Autenticação
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Create a new user
    /// </summary>
    /// <param name="request">User object</param>
    /// <returns>Created user</returns>
    Task<string> RegisterAsync(UserRegisterDTO request);

    /// <summary>
    /// Adiciona os Dados Adicionais no Usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="additionalData"></param>
    /// <returns></returns>
    Task<string> AddUserAdditionalDataAsync(int userId, UserAdditionalDataDTO additionalData);

    /// <summary>
    /// Adiciona o Endereço no Usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="address"></param>
    /// <returns></returns>
    Task<string> AddAddress(int userId, [FromBody] AddressDTO address);

    /// <summary>
    /// Serviço de Logar usuário.
    /// </summary>
    Task<string> LoginAsync(UserLoginDTO request);

    /// <summary>
    /// Serviço de Atualizar usuário.
    /// </summary>
    /// <param name="oldEmail">User email</param>
    /// <param name="request">User object</param>
    Task<string> UpdateUserByEmailAsync(string oldEmail, UserUpdateDTO request);

    /// <summary>
    /// Serviço de Deletar usuário.
    /// </summary>
    /// <param name="id">User ID</param>
    /// <returns>Deleted user</returns>
    Task<string> DeleteUserAsync(int id);

    /// <summary>
    /// Serviço de Reativar usuário.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<string> ReactiveUserAsync(int userId);

    /// <summary>
    /// Serviço de Recuperar a Senha
    /// </summary>
    /// <param name="actualEmail">User email</param>
    Task<string> ForgotPasswordUserAsync(string actualEmail);
}
