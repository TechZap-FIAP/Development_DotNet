using APITechZap.Models;

namespace APITechZap.Repository.Interface;

public interface ISolarPanelTypeRepository
{
    Task<IEnumerable<SolarPanelType>> GetAllSolarPanelTypesAsync();
    Task<SolarPanelType> GetSolarPanelTypeByIdAsync(int id);
    Task <string> AddSolarPanelTypeAsync(SolarPanelType solarPanelType);
    Task <string> UpdateSolarPanelTypeAsync(SolarPanelType solarPanelType);
    Task <string> DeleteSolarPanelTypeAsync(int id);
}
