using APITechZap.Models;

namespace APITechZap.Repository.Interface;

public interface IUserAdditionalDataRepository
{
    Task <string> AddUserAdditionalDataAsync(UserAdditionalData userAdditionalData);
    Task <string> UpdateUserAdditionalDataAsync(UserAdditionalData userAdditionalData);
    Task<UserAdditionalData> GetUserAdditionalDataByUserIdAsync(int userId);
}
