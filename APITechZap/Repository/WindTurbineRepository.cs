using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Models.DTOs;
using APITechZap.Models.DTOs.WindTurbineDTOs;
using APITechZap.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace APITechZap.Repository;

/// <summary>
/// Wind Turbine Repository
/// </summary>
public class WindTurbineRepository : IWindTurbineRepository
{
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Constructor for WindTurbineRepository
    /// </summary>
    /// <param name="dbContext"></param>
    public WindTurbineRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get all Wind Turbines
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<IEnumerable<WindTurbineDTO>> GetAllWindTurbinesAsync()
    {
        var windTurbines = await _dbContext.WindTurbines.Include(s => s.WindTurbineType).ToListAsync() ?? throw new Exception("Turbinas Eólicas não encontrados!");

        try
        {
            var windTurbineDTOs = windTurbines.Select(s => new WindTurbineDTO
            {
                DsMaterial = s.DsMaterial,
                DsSize = s.DsSize,
                DsPrice = s.DsPrice,
                WindTurbineTypeDTO = s.WindTurbineType != null ? new WindTurbineTypeDTO
                {
                    DsVoltage = s.WindTurbineType.DsVoltage,
                    DsModel = s.WindTurbineType.DsModel,
                    DsManufacturer = s.WindTurbineType.DsManufacturer,
                    DsGeneratorType = s.WindTurbineType.DsGeneratorType,
                    DsWarrantyYears = s.WindTurbineType.DsWarrantyYears
                } : null
            });

            return windTurbineDTOs;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar Painéis Solares!", ex);
        }
    }

    /// <summary>
    /// Get Wind Turbine by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<WindTurbineDTO> GetWindTurbineByIdAsync(int id)
    {
        var windTurbine = await _dbContext.WindTurbines.Include(w => w.WindTurbineType).FirstOrDefaultAsync(w => w.IdWindTurbine == id) ?? throw new Exception("Turbina Eólica não encontrado ou desativado!");

        try
        {
            var windTurbineDTO = new WindTurbineDTO
            {
                DsMaterial = windTurbine.DsMaterial,
                DsSize = windTurbine.DsSize,
                DsPrice = windTurbine.DsPrice,
                WindTurbineTypeDTO = windTurbine.WindTurbineType != null ? new WindTurbineTypeDTO
                {
                    DsVoltage = windTurbine.WindTurbineType.DsVoltage,
                    DsModel = windTurbine.WindTurbineType.DsModel,
                    DsManufacturer = windTurbine.WindTurbineType.DsManufacturer,
                    DsGeneratorType = windTurbine.WindTurbineType.DsGeneratorType,
                    DsWarrantyYears = windTurbine.WindTurbineType.DsWarrantyYears,
                } : null
            };

            return windTurbineDTO;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar a Turbina Eólica!", ex);
        }
    }
}
