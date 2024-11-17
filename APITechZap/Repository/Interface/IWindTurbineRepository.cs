using APITechZap.Models;

namespace APITechZap.Repository.Interface;

public interface IWindTurbineRepository
{
    Task<IEnumerable<WindTurbine>> GetAllWindTurbinesAsync();
    Task<WindTurbine> GetWindTurbineByIdAsync(int id);
    Task <string> AddWindTurbineAsync(WindTurbine windTurbine);
    Task <string> UpdateWindTurbineAsync(WindTurbine windTurbine);
    Task <string> DeleteWindTurbineAsync(int id);
}
