using APITechZap.Models.DTOs.AddressDTOs;
using APITechZap.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITechZap.Controllers;

/// <summary>
/// Controller para manipulação de endereços
/// </summary>
[Route("api/address")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressRepository _addressRepository;

    public AddressController(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    /// <summary>
    /// Método para buscar o endereço de um usuário pelo ID
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAddressByUserId(int userId)
    {
        try
        {
            var address = await _addressRepository.GetAddressByUserIdAsync(userId);
            return Ok(address);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    /// <summary>
    /// Método para adicionar um endereço de um usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("{userId}")]
    public async Task<IActionResult> AddAddressByUserId(int userId, [FromBody] AddressDTO request)
    {
        try
        {
            var address = await _addressRepository.AddAddressAsync(userId, request);
            return Ok(address);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    /// <summary>
    /// Método para atualizar o endereço de um usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateAddressByUserId(int userId, [FromBody] AddressUpdateDTO request)
    {
        try
        {
            var address = await _addressRepository.UpdateAddressAsync(userId, request);
            return Ok(address);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
