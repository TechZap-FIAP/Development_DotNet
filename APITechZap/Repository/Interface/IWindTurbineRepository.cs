using APITechZap.Models;
using APITechZap.Models.DTOs.WindTurbineDTOs;

namespace APITechZap.Repository.Interface;

public interface IWindTurbineRepository
{
    Task<IEnumerable<WindTurbineDTO>> GetAllWindTurbinesAsync();
    Task<WindTurbineDTO> GetWindTurbineByIdAsync(int id);
}
