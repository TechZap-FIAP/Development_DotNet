using APITechZap.Models;
using APITechZap.Repository.Interface;

namespace APITechZap.Repository;

public class SolarPanelTypeRepository : ISolarPanelTypeRepository
{
    public Task<string> AddSolarPanelTypeAsync(SolarPanelType solarPanelType)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteSolarPanelTypeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SolarPanelType>> GetAllSolarPanelTypesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SolarPanelType> GetSolarPanelTypeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateSolarPanelTypeAsync(SolarPanelType solarPanelType)
    {
        throw new NotImplementedException();
    }
}
