using APITechZap.Models;
using APITechZap.Models.DTOs.UserAdditionalDataDTOs;
using APITechZap.Models.DTOs.UserDTOs;
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
    /// Serviço de Logar usuário.
    /// </summary>
    Task<string> LoginAsync(UserLoginDTO request);

    /// <summary>
    /// Serviço de Atualizar usuário.
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <param name="request">User object</param>
    Task<string> UpdateUserByIdAsync(int userId, UserUpdateDTO request);

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
