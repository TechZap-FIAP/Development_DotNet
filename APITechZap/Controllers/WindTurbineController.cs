using APITechZap.Models.DTOs.WindTurbineDTOs;
using APITechZap.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITechZap.Controllers;

/// <summary>
/// Wind Turbine Controller
/// </summary>
[Route("api/wind-turbine")]
[ApiController]
[Tags("Produtos - Turbina Eólica")]
public class WindTurbineController : ControllerBase
{
    private readonly IWindTurbineRepository _windTurbineRepository;

    /// <summary>
    /// Constructor for WindTurbineController
    /// </summary>
    /// <param name="windTurbineRepository">Repositório de turbinas eólicas</param>
    public WindTurbineController(IWindTurbineRepository windTurbineRepository)
    {
        _windTurbineRepository = windTurbineRepository;
    }

    /// <summary>
    /// Adiciona uma nova turbina eólica
    /// </summary>
    /// <param name="request">Dados da turbina eólica a ser adicionada</param>
    /// <returns>Resultado da operação de adição</returns>
    /// <response code="200">Turbina eólica adicionada com sucesso.</response>
    /// <response code="500">Erro ao adicionar turbina eólica.</response>
    [HttpPost]
    public async Task<IActionResult> AddWindTurbinesAsync([FromBody] WindTurbineDTO request)
    {
        try
        {
            var windTurbines = await _windTurbineRepository.AddWindTurbineAsync(request);
            return Ok(windTurbines);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    /// <summary>
    /// Adiciona um tipo de turbina eólica
    /// </summary>
    /// <param name="windTurbineId">ID da turbina eólica</param>
    /// <param name="request">Dados do tipo de turbina a ser adicionado</param>
    /// <returns>Resultado da operação de adição</returns>
    /// <response code="200">Tipo de turbina eólica adicionado com sucesso.</response>
    /// <response code="500">Erro ao adicionar tipo de turbina eólica.</response>
    [HttpPost("type/{windTurbineId}")]
    public async Task<IActionResult> AddWindTurbineTypesAsync(int windTurbineId, [FromBody] WindTurbineTypeDTO request)
    {
        try
        {
            var windTurbineType = await _windTurbineRepository.AddWindTurbineTypeAsync(windTurbineId, request);
            return Ok(windTurbineType);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    /// <summary>
    /// Obtém todas as turbinas eólicas
    /// </summary>
    /// <returns>Lista de turbinas eólicas</returns>
    /// <response code="200">Turbinas eólicas retornadas com sucesso.</response>
    /// <response code="500">Erro ao buscar turbinas eólicas.</response>
    [HttpGet]
    public async Task<IActionResult> GetAllWindTurbinesAsync()
    {
        try
        {
            var windTurbines = await _windTurbineRepository.GetAllWindTurbinesAsync();

            return Ok(windTurbines);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    /// <summary>
    /// Obtém uma turbina eólica pelo ID
    /// </summary>
    /// <param name="id">ID da turbina eólica</param>
    /// <returns>Detalhes da turbina eólica</returns>
    /// <response code="200">Turbina eólica encontrada com sucesso.</response>
    /// <response code="404">Turbina eólica não encontrada.</response>
    /// <response code="500">Erro ao buscar turbina eólica.</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWindTurbineByIdAsync(int id)
    {
        try
        {
            var windTurbine = await _windTurbineRepository.GetWindTurbineByIdAsync(id);

            return Ok(windTurbine);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
