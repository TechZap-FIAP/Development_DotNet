using APITechZap.Models;
using APITechZap.Models.DTOs.WindTurbineDTOs;

namespace APITechZap.Repository.Interface;

/// <summary>
/// Interface de Repositório de Turbina Eólica
/// </summary>
public interface IWindTurbineRepository
{
    /// <summary>
    /// Busca todas as Turbinas Eólicas
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<WindTurbineDetailedDTO>> GetAllWindTurbinesAsync();

    /// <summary>
    /// Busca a Turbina Eólica pelo ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<WindTurbineDetailedDTO> GetWindTurbineByIdAsync(int id);

    /// <summary>
    /// Adiciona a Turbina Eólica
    /// </summary>
    /// <param name="windTurbineDTO"></param>
    /// <returns></returns>
    Task<string> AddWindTurbineAsync(WindTurbineDTO windTurbineDTO);

    /// <summary>
    /// Adiciona o Tipo de Turbina Eólica
    /// </summary>
    /// <param name="windTurbineId"></param>
    /// <param name="windTurbineTypeDTO"></param>
    /// <returns></returns>
    Task<string> AddWindTurbineTypeAsync(int windTurbineId, WindTurbineTypeDTO windTurbineTypeDTO);
}
