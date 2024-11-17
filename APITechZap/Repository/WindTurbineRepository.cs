using APITechZap.Models;
using APITechZap.Repository.Interface;

namespace APITechZap.Repository;

public class WindTurbineRepository : IWindTurbineRepository
{
    public Task<string> AddWindTurbineAsync(WindTurbine windTurbine)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteWindTurbineAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WindTurbine>> GetAllWindTurbinesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<WindTurbine> GetWindTurbineByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateWindTurbineAsync(WindTurbine windTurbine)
    {
        throw new NotImplementedException();
    }
}
