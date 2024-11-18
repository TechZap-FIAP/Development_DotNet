using APITechZap.Models;

namespace APITechZap.Repository.Interface;

public interface IAddressRepository
{
    Task <string> AddAddressAsync(Address address);
    Task <string> UpdateAddressAsync(Address address);
    Task<Address> GetAddressByUserIdAsync(int id);
}
