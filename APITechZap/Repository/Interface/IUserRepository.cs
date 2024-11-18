using APITechZap.Models;

namespace APITechZap.Repository.Interface;

public interface IUserRepository
{
    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns>List of users</returns>
    Task<IEnumerable<User>> GetAllUsersAsync();

    /// <summary>
    /// Get a user by ID
    /// </summary>
    /// <param name="id">User ID</param>
    /// <returns>User</returns>
    Task<User> GetUserByIdAsync(int id);

    Task<bool> EmailExistsAsync(string email);
}
