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
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Constructor for UserRepository
    /// </summary>
    /// <param name="context"></param>
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get all Users
    /// </summary>
    /// <returns>Return All Users</returns>
    /// <exception cref="Exception">Usuários não encontrados!</exception>
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var users = await _context.Users.Include(u => u.UserAdditionalData).ToListAsync();
        if (users == null)
        {
            throw new Exception("Usuários não encontrados!");
        }
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
        var user = await _context.Users.Include(u => u.UserAdditionalData).FirstOrDefaultAsync(u => u.IdUser == id);
        if (user == null)
        {
            throw new Exception("Usuário não encontrado!");
        }

        return user;
    }
}
