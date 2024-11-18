using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace APITechZap.Repository;

/// <summary>
/// User Repository
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Constructor for UserRepository
    /// </summary>
    /// <param name="dbContext"></param>
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get all Users
    /// </summary>
    /// <returns>Return All Users</returns>
    /// <exception cref="Exception">Usuários não encontrados!</exception>
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var users = await _dbContext.Users.Include(u => u.UserAdditionalData).Include(u => u.Address).ToListAsync() ?? throw new Exception("Usuários não encontrados!");

        return users;
    }

    /// <summary>
    /// Get User by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Return User by Id</returns>
    /// <exception cref="Exception">Usuário não encontrado!</exception>
    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await _dbContext.Users.Include(u => u.UserAdditionalData).Include(u => u.Address).FirstOrDefaultAsync(u => u.IdUser == id) ?? throw new Exception("Usuário não encontrado!");

        return user;
    }

    /// <summary>
    /// Verify if Email exists
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _dbContext.Users.AnyAsync(u => u.DsEmail == email);
    }
}
