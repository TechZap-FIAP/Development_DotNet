using APITechZap.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITechZap.Controllers;

/// <summary>
/// Wind Turbine Controller
/// </summary>
[Route("api/wind-turbine")]
[ApiController]
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
