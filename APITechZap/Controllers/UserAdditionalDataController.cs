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
    /// <param name="userAdditionalDataRepository">Repositório dos dados adicionais dos usuários</param>
    public UserAdditionalDataController(IUserAdditionalDataRepository userAdditionalDataRepository)
    {
        _userAdditionalDataRepository = userAdditionalDataRepository;
    }

    /// <summary>
    /// Método para buscar os dados adicionais de um usuário pelo ID
    /// </summary>
    /// <param name="userId">ID do usuário cujos dados adicionais serão buscados</param>
    /// <returns></returns>
    /// <response code="200">Dados adicionais do usuário encontrados com sucesso.</response>
    /// <response code="404">Dados adicionais do usuário não encontrados.</response>
    /// <response code="500">Erro ao buscar dados adicionais do usuário.</response>
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
    /// <param name="userId">ID do usuário ao qual os dados adicionais serão adicionados</param>
    /// <param name="request">Dados adicionais a serem adicionados</param>
    /// <returns></returns>
    /// <response code="200">Dados adicionais do usuário adicionados com sucesso.</response>
    /// <response code="400">Dados inválidos para adicionar.</response>
    /// <response code="500">Erro ao adicionar dados adicionais do usuário.</response>
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
    /// <param name="userId">ID do usuário cujos dados adicionais serão atualizados</param>
    /// <param name="request">Novos dados adicionais</param>
    /// <returns></returns>
    /// <response code="200">Dados adicionais do usuário atualizados com sucesso.</response>
    /// <response code="404">Dados adicionais do usuário não encontrados para atualização.</response>
    /// <response code="500">Erro ao atualizar dados adicionais do usuário.</response>
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
