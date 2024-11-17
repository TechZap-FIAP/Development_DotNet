using APITechZap.Models;
using APITechZap.Repository.Interface;

namespace APITechZap.Repository;

public class WindTurbineTypeRepository : IWindTurbineTypeRepository
{
    public Task<string> AddWindTurbineTypeAsync(WindTurbineType windTurbineType)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteWindTurbineTypeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WindTurbineType>> GetAllWindTurbineTypesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<WindTurbineType> GetWindTurbineTypeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateWindTurbineTypeAsync(WindTurbineType windTurbineType)
    {
        throw new NotImplementedException();
    }
}
