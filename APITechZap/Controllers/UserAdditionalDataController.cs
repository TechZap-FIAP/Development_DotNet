using APITechZap.Models;
using APITechZap.Models.DTOs.UserAdditionalDataDTOs;
using APITechZap.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITechZap.Controllers;

/// <summary>
/// Controller para manipulação de dados adicionais de usuários
/// </summary>
[Route("api/user-additional-data")]
[ApiController]
[Tags("Usuário - Dados Adicionais")]
public class UserAdditionalDataController : ControllerBase
{
    private readonly IUserAdditionalDataRepository _userAdditionalDataRepository;

    /// <summary>
    /// Construtor da classe UserAdditionalDataController
    /// </summary>
    /// <param name="userAdditionalDataRepository"></param>
    public UserAdditionalDataController(IUserAdditionalDataRepository userAdditionalDataRepository)
    {
        _userAdditionalDataRepository = userAdditionalDataRepository;
    }

    /// <summary>
    /// Método para buscar os dados adicionais de um usuário pelo ID
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserAdditionalDataByUserId(int userId)
    {
        try
        {
            var userAdditionalData = await _userAdditionalDataRepository.GetUserAdditionalDataByUserIdAsync(userId);
            return Ok(userAdditionalData);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    /// <summary>
    /// Método para adicionar os dados adicionais de um usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("{userId}")]
    public async Task<IActionResult> AddUserAdditionalDataByUserId(int userId, [FromBody] UserAdditionalDataDTO request)
    {
        try
        {
            var userAdditionalData = await _userAdditionalDataRepository.AddUserAdditionalDataAsync(userId, request);
            return Ok(userAdditionalData);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    /// <summary>
    /// Método para atualizar os dados adicionais de um usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUserAdditionalDataByUserId(int userId, [FromBody] UserAdditionalDataUpdateDTO request)
    {
        try
        {
            var userAdditionalDataUpdated = await _userAdditionalDataRepository.UpdateUserAdditionalDataAsync(userId, request);
            return Ok(userAdditionalDataUpdated);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

}
