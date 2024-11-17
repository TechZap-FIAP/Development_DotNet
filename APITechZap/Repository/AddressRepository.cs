using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace APITechZap.Repository;

/// <summary>
/// Classe de Repositório de Endereço
/// </summary>
public class AddressRepository : IAddressRepository
{
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Construtor da Classe AddressRepository
    /// </summary>
    /// <param name="dbContext"></param>
    public AddressRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Método para Obter todos os Endereços
    /// </summary>
    /// <returns></returns>

    public async Task<IEnumerable<Address>> GetAllAddressesAsync()
    {
        return await _dbContext.Addresses.ToListAsync();
    }

    /// <summary>
    /// Método para Obter Endereço por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Address?> GetAddressByIdAsync(int id)
    {
        return await _dbContext.Addresses.FindAsync(id);
    }

    /// <summary>
    /// Método para Adicionar Endereço
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    public async Task<string> AddAddressAsync(Address address)
    {
        await _dbContext.Addresses.AddAsync(address);
        await _dbContext.SaveChangesAsync();

        return "Endereço Adicionado com Sucesso!";
    }

    /// <summary>
    /// Método para Atualizar Endereço
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    public async Task<string> UpdateAddressAsync(Address address)
    {
        _dbContext.Addresses.Update(address);
        await _dbContext.SaveChangesAsync();

        return "Endereço Atualizado com Sucesso!";
    }

    /*
    public async Task<string> DeleteAddressAsync(int id)
    {
        var address = await GetAddressByIdAsync(id);
        if (address != null)
        {
            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();
        }

        return "Endereço Deletado com Sucesso";
    }
    */
}
