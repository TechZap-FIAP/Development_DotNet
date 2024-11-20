using APITechZap.Models;
using APITechZap.Models.DTOs.AddressDTOs;
using Microsoft.AspNetCore.Mvc;

namespace APITechZap.Repository.Interface;

/// <summary>
/// Interface de Repositório de Endereço
/// </summary>
public interface IAddressRepository
{
    /// <summary>
    /// Adiciona o Endereço no Usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<string> AddAddressAsync(int userId, AddressDTO request);

    /// <summary>
    /// Atualiza o Endereço do Usuário
    /// </summary>
    /// <param name="request"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<string> UpdateAddressAsync(int userId, AddressUpdateDTO request);

    /// <summary>
    /// Busca o Endereço pelo ID do Usuário
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Address> GetAddressByUserIdAsync(int id);
}
