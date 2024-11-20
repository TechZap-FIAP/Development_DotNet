using APITechZap.Models;
using APITechZap.Models.DTOs.SolarPanelDTOs;

namespace APITechZap.Repository.Interface;

public interface ISolarPanelRepository
{
    Task<IEnumerable<SolarPanelDTO>> GetAllSolarPanelsAsync();
    Task<SolarPanelDTO> GetSolarPanelByIdAsync(int id);
}
