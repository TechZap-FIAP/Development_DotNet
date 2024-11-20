using APITechZap.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITechZap.Controllers;

/// <summary>
/// Wind Turbine Controller
/// </summary>
[Route("api/solar-panel")]
[ApiController]
public class SolarPanelController : ControllerBase
{

    private readonly ISolarPanelRepository _solarPanelRepository;

    /// <summary>
    /// Constructor for SolarPanelController
    /// </summary>
    /// <param name="solarPanelRepository"></param>
    public SolarPanelController(ISolarPanelRepository solarPanelRepository)
    {
        _solarPanelRepository = solarPanelRepository;
    }

    /// <summary>
    /// Get all Solar Panels
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllSolarPanelsAsync()
    {
        try
        {
            var solarPanels = await _solarPanelRepository.GetAllSolarPanelsAsync();

            return Ok(solarPanels);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    /// <summary>
    /// Get Solar Panel by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSolarPanelByIdAsync(int id)
    {
        try
        {
            var solarPanel = await _solarPanelRepository.GetSolarPanelByIdAsync(id);

            return Ok(solarPanel);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

}
