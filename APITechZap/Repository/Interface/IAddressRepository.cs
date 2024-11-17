using APITechZap.Models;

namespace APITechZap.Repository.Interface;

public interface IAddressRepository
{
    Task<IEnumerable<Address>> GetAllAddressesAsync();
    Task<Address?> GetAddressByIdAsync(int id);
    Task <string> AddAddressAsync(Address address);
    Task <string> UpdateAddressAsync(Address address);
    //Task <string> DeleteAddressAsync(int id);
}
