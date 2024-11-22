using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Models.DTOs.AddressDTOs;
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
    /// Método para adicionar o Endereço nos Dados Adicionais
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> AddAddressAsync(int userId, AddressDTO request)
    {
        var user = await _dbContext.Users
            .Include(a => a.Address)
            .FirstOrDefaultAsync(a => a.IdUser == userId && a.DtDeletedAt == null) 
            ?? throw new Exception("Usuário não encontrado.");

        var address = new Address
        {
            DsStreet = request.DsStreet,
            DsNumber = request.DsNumber,
            DsComplement = request.DsComplement,
            DsNeighborhood = request.DsNeighborhood,
            DsCity = request.DsCity,
            DsState = request.DsState,
            DsZipCode = request.DsZipCode,
            IdUser = user.IdUser
        };

        try
        {
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();

            return "Endereço Adicionado com Sucesso";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// Método para atualizar o endereço
    /// </summary>
    /// <param name="request"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<string> UpdateAddressAsync(int userId, AddressUpdateDTO request)
    {
        var user = await _dbContext.Users
            .Include(a => a.Address)
            .FirstOrDefaultAsync(a => a.IdUser == userId && a.DtDeletedAt == null) 
            ?? throw new Exception("Usuário não encontrado.");

        var address = await _dbContext.Addresses.
            FirstOrDefaultAsync(a => a.IdUser == userId && a.DtDeletedAt == null) 
            ?? throw new Exception("Endereço não encontrado!");

        if (request.DsStreet != null)
        {
            address.DsStreet = request.DsStreet;
        }

        if (request.DsNumber != null)
        {
            address.DsNumber = request.DsNumber;
        }

        if (request.DsComplement != null)
        {
            address.DsComplement = request.DsComplement;
        }

        if (request.DsNeighborhood != null)
        {
            address.DsNeighborhood = request.DsNeighborhood;
        }

        if (request.DsCity != null)
        {
            address.DsCity = request.DsCity;
        }

        if (request.DsState != null)
        {
            address.DsState = request.DsState;
        }

        if (request.DsZipCode != null)
        {
            address.DsZipCode = request.DsZipCode;
        }

        address.DtUpdatedAt = DateTime.Now;

        try
        {
            await _dbContext.SaveChangesAsync();

            return "Endereço Atualizado com Sucesso";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// Método para buscar o endereço pelo Id do Usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<AddressDetailedDTO> GetAddressByUserIdAsync(int userId)
    {
        var address = await _dbContext.Addresses
            .FirstOrDefaultAsync(a => a.IdUser == userId && a.DtDeletedAt == null) 
            ?? throw new Exception("Usuário não encontrado!");

        var addressDTO = new AddressDetailedDTO
        {
            IdAddress = address.IdAddress,
            DsStreet = address.DsStreet,
            DsNumber = address.DsNumber,
            DsComplement = address.DsComplement,
            DsNeighborhood = address.DsNeighborhood,
            DsCity = address.DsCity,
            DsState = address.DsState,
            DsZipCode = address.DsZipCode
        };

        return addressDTO;
    }
}
