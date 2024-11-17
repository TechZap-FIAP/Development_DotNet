using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace APITechZap.Repository;

public class UserAdditionalDataRepository : IUserAdditionalDataRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserAdditionalDataRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> AddUserAdditionalDataAsync(UserAdditionalData userAdditionalData)
    {
        await _dbContext.UserAdditionalDatas.AddAsync(userAdditionalData);
        await _dbContext.SaveChangesAsync();

        return "User additional data added successfully";
    }

    public async Task<string> DeleteUserAdditionalDataAsync(int id)
    {
        var additionalData = await GetUserAdditionalDataByIdAsync(id);
        if (additionalData != null)
        {
            _dbContext.UserAdditionalDatas.Remove(additionalData);
            await _dbContext.SaveChangesAsync();
            return "User additional data deleted successfully";
        }

        return "User additional data not found";
    }

    public async Task<IEnumerable<UserAdditionalData>> GetAllUserAdditionalDatasAsync()
    {
        return await _dbContext.UserAdditionalDatas.ToListAsync();
    }

    public async Task<UserAdditionalData?> GetUserAdditionalDataByIdAsync(int id)
    {
        return await _dbContext.UserAdditionalDatas.FindAsync(id);
    }

    public async Task<string> UpdateUserAdditionalDataAsync(UserAdditionalData userAdditionalData)
    {
        _dbContext.UserAdditionalDatas.Update(userAdditionalData);
        await _dbContext.SaveChangesAsync();

        return "User additional data updated successfully";
    }
}
