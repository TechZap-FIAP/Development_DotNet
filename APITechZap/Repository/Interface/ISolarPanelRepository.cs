using APITechZap.Models;

namespace APITechZap.Repository.Interface;

public interface ISolarPanelRepository
{
    Task<IEnumerable<SolarPanel>> GetAllSolarPanelsAsync();
    Task<SolarPanel> GetSolarPanelByIdAsync(int id);
    Task <string> AddSolarPanelAsync(SolarPanel solarPanel);
    Task <string> UpdateSolarPanelAsync(SolarPanel solarPanel);
    Task <string> DeleteSolarPanelAsync(int id);
}
