using APITechZap.Models.DTOs.SolarPanelDTOs;
using APITechZap.Models.DTOs.WindTurbineDTOs;
using APITechZap.Repository;
using APITechZap.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITechZap.Controllers;

/// <summary>
/// Wind Turbine Controller
/// </summary>
[Route("api/solar-panel")]
[ApiController]
[Tags("Produtos - Painel Solar")]
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
    /// Adiciona o Painel Solar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddSolarPanelAsync([FromBody] SolarPanelDTO request)
    {
        try
        {
            var solarPanels = await _solarPanelRepository.AddSolarPanelAsync(request);
            return Ok(request);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    /// <summary>
    /// Adiciona o Tipo do Painel Solar
    /// </summary>
    /// <param name="solarPanelId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("type/{solarPanelId}")]
    public async Task<IActionResult> AddSolarPanelTypesAsync(int solarPanelId, [FromBody] SolarPanelTypeDTO request)
    {
        try
        {
            var solarPanelType = await _solarPanelRepository.AddSolarPanelTypeAsync(solarPanelId, request);
            return Ok(solarPanelType);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
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
