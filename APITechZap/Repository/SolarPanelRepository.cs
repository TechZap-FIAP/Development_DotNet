using APITechZap.Models;
using APITechZap.Repository.Interface;

namespace APITechZap.Repository;

public class SolarPanelRepository : ISolarPanelRepository
{
    public Task<string> AddSolarPanelAsync(SolarPanel solarPanel)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteSolarPanelAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SolarPanel>> GetAllSolarPanelsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SolarPanel> GetSolarPanelByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateSolarPanelAsync(SolarPanel solarPanel)
    {
        throw new NotImplementedException();
    }
}
