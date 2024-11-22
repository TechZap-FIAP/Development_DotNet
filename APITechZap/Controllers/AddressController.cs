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
[Tags("Usuário - Endereço")]
public class AddressController : ControllerBase
{
    private readonly IAddressRepository _addressRepository;

    /// <summary>
    /// Construtor da classe
    /// </summary>
    /// <param name="addressRepository"></param>
    public AddressController(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    /// <summary>
    /// Método para buscar o endereço de um usuário pelo ID
    /// </summary>
    /// <param name="userId">ID do usuário cujo endereço será buscado</param>
    /// <returns></returns>
    /// <response code="200">Endereço encontrado com sucesso.</response>
    /// <response code="404">Endereço não encontrado.</response>
    /// <response code="500">Erro ao buscar endereço.</response>
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
    /// <param name="userId">ID do usuário para quem o endereço será adicionado</param>
    /// <param name="request">Dados do endereço a ser adicionado</param>
    /// <returns></returns>
    /// <response code="200">Endereço adicionado com sucesso.</response>
    /// <response code="400">Dados inválidos para adicionar endereço.</response>
    /// <response code="500">Erro ao adicionar endereço.</response>
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
    /// <param name="userId">ID do usuário cujo endereço será atualizado</param>
    /// <param name="request">Novos dados do endereço</param>
    /// <returns></returns>
    /// <response code="200">Endereço atualizado com sucesso.</response>
    /// <response code="404">Endereço não encontrado para atualização.</response>
    /// <response code="500">Erro ao atualizar endereço.</response>
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
