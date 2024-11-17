using APITechZap.Models;

namespace APITechZap.Repository.Interface;

public interface IUserAdditionalDataRepository
{
    Task<IEnumerable<UserAdditionalData>> GetAllUserAdditionalDatasAsync();
    Task<UserAdditionalData?> GetUserAdditionalDataByIdAsync(int id);
    Task <string> AddUserAdditionalDataAsync(UserAdditionalData userAdditionalData);
    Task <string> UpdateUserAdditionalDataAsync(UserAdditionalData userAdditionalData);
    Task <string> DeleteUserAdditionalDataAsync(int id);
}
