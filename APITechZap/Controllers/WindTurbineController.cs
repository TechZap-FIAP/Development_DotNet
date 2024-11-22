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
    /// <param name="windTurbineRepository"></param>
    public WindTurbineController(IWindTurbineRepository windTurbineRepository)
    {
        _windTurbineRepository = windTurbineRepository;
    }

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
    /// Get all Wind Turbines
    /// </summary>
    /// <returns></returns>
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
    /// Get Wind Turbine by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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
