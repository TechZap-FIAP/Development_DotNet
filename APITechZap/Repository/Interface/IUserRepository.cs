using APITechZap.Models;
using APITechZap.Models.DTOs.UserDTOs;

namespace APITechZap.Repository.Interface;

/// <summary>
/// User Interface Repository
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns>List of users</returns>
    Task<IEnumerable<UserDetailedDTO>> GetAllUsersAsync();

    /// <summary>
    /// Get a user by ID
    /// </summary>
    /// <param name="id">User ID</param>
    /// <returns>User</returns>
    Task<UserDetailedDTO> GetUserByIdAsync(int id);

    /// <summary>
    /// Verifica se o E-mail já existe
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<bool> EmailExistsAsync(string email);
}
