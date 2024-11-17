using APITechZap.Models;

namespace APITechZap.Repository.Interface;

public interface IWindTurbineTypeRepository
{
    Task<IEnumerable<WindTurbineType>> GetAllWindTurbineTypesAsync();
    Task<WindTurbineType> GetWindTurbineTypeByIdAsync(int id);
    Task <string> AddWindTurbineTypeAsync(WindTurbineType windTurbineType);
    Task <string> UpdateWindTurbineTypeAsync(WindTurbineType windTurbineType);
    Task <string> DeleteWindTurbineTypeAsync(int id);
}
