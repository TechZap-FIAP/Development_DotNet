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
    /// Método para adicionar o endereço
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    public async Task<string> AddAddressAsync(Address address)
    {
        await _dbContext.Addresses.AddAsync(address);
        await _dbContext.SaveChangesAsync();

        return "Endereço Adicionado com Sucesso";
    }

    /// <summary>
    /// Método para atualizar o endereço
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    public async Task<string> UpdateAddressAsync(Address address)
    {
        _dbContext.Addresses.Update(address);
        await _dbContext.SaveChangesAsync();

        return "Endereço Atualizado com Sucesso";
    }

    /// <summary>
    /// Método para buscar o endereço pelo Id do Usuário
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Address> GetAddressByUserIdAsync(int UserId)
    {

        var address = await _dbContext.Addresses.FirstOrDefaultAsync(a => a.IdUser == UserId) ?? throw new Exception("Endereço não encontrado!");

        return address;
    }
}
