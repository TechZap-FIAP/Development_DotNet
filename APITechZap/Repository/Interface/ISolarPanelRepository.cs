using APITechZap.Models;
using APITechZap.Models.DTOs.SolarPanelDTOs;

namespace APITechZap.Repository.Interface;

/// <summary>
/// Interface de Repositório de Painel Solar
/// </summary>
public interface ISolarPanelRepository
{
    /// <summary>
    /// Busca todos os Painéis Solares
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<SolarPanelDetailedDTO>> GetAllSolarPanelsAsync();

    /// <summary>
    /// Busca o Painel Solar pelo ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<SolarPanelDetailedDTO> GetSolarPanelByIdAsync(int id);

    /// <summary>
    /// Adiciona o Painel Solar
    /// </summary>
    /// <param name="solarPanelDTO"></param>
    /// <returns></returns>
    Task<string> AddSolarPanelAsync(SolarPanelDTO solarPanelDTO);

    /// <summary>
    /// Adiciona o Tipo de Painel Solar
    /// </summary>
    /// <param name="solarPanelId"></param>
    /// <param name="solarPanelTypeDTO"></param>
    /// <returns></returns>
    Task<string> AddSolarPanelTypeAsync(int solarPanelId, SolarPanelTypeDTO solarPanelTypeDTO);
}
