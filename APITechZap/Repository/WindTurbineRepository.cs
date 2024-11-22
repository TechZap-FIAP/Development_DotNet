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
    /// Adiciona a Turbina Eólica
    /// </summary>
    /// <param name="windTurbineDTO"></param>
    /// <returns></returns>
    public async Task<string> AddWindTurbineAsync(WindTurbineDTO windTurbineDTO)
    {
        var windTurbine = new WindTurbine
        {
            DsMaterial = windTurbineDTO.DsMaterial,
            DsSize = windTurbineDTO.DsSize,
            DsPrice = windTurbineDTO.DsPrice
        };

        try
        {
            await _dbContext.WindTurbines.AddAsync(windTurbine);
            await _dbContext.SaveChangesAsync();

            return "Turbina Eólica Adicionada com Sucesso";
        }
        catch (Exception ex)
        {
           throw new Exception("Erro ao adicionar a Turbina Eólica!", ex);
        }
    }

    /// <summary>
    /// Adiciona o Tipo de Turbina Eólica
    /// </summary>
    /// <param name="windTurbineId"></param>
    /// <param name="windTurbineTypeDTO"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> AddWindTurbineTypeAsync(int windTurbineId, WindTurbineTypeDTO windTurbineTypeDTO)
    {
        var windTurbine = await _dbContext.WindTurbines
            .Include(w => w.WindTurbineType)
            .FirstOrDefaultAsync(w => w.IdWindTurbine == windTurbineId && w.DtDeletedAt == null)
            ?? throw new Exception("Turbina Eólica não encontrada!");

        var windTurbineType = new WindTurbineType
        {
            DsVoltage = windTurbineTypeDTO.DsVoltage,
            DsModel = windTurbineTypeDTO.DsModel,
            DsManufacturer = windTurbineTypeDTO.DsManufacturer,
            DsGeneratorType = windTurbineTypeDTO.DsGeneratorType,
            DsWarrantyYears = windTurbineTypeDTO.DsWarrantyYears,
            IdWindTurbine = windTurbine.IdWindTurbine
        };

        try
        {
            await _dbContext.WindTurbineTypes.AddAsync(windTurbineType);
            await _dbContext.SaveChangesAsync();

            return "Tipo de Turbina Eólica Adicionado com Sucesso";
        }
        catch (Exception ex) 
        {
            throw new Exception("Erro ao adicionar o Tipo Turbinas Eólicas!", ex);
        }
    }

    /// <summary>
    /// Get all Wind Turbines
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<IEnumerable<WindTurbineDetailedDTO>> GetAllWindTurbinesAsync()
    {
        var windTurbines = await _dbContext.WindTurbines
            .Include(w => w.WindTurbineType)
            .ToListAsync() 
            ?? throw new Exception("Turbinas Eólicas não encontrados!");

        try
        {
            var windTurbineDTOs = windTurbines.Select(w => new WindTurbineDetailedDTO
            {
                IdWindTurbine = w.IdWindTurbine,
                DsMaterial = w.DsMaterial,
                DsSize = w.DsSize,
                DsPrice = w.DsPrice,
                WindTurbineTypeDTO = w.WindTurbineType != null ? new WindTurbineTypeDetailedDTO
                {
                    IdWindTurbineType = w.WindTurbineType.IdWindTurbineType,
                    DsVoltage = w.WindTurbineType.DsVoltage,
                    DsModel = w.WindTurbineType.DsModel,
                    DsManufacturer = w.WindTurbineType.DsManufacturer,
                    DsGeneratorType = w.WindTurbineType.DsGeneratorType,
                    DsWarrantyYears = w.WindTurbineType.DsWarrantyYears
                } : null
            });

            return windTurbineDTOs;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar as Turbinas Eólicas!", ex);
        }
    }

    /// <summary>
    /// Get Wind Turbine by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<WindTurbineDetailedDTO> GetWindTurbineByIdAsync(int id)
    {
        var windTurbine = await _dbContext.WindTurbines
            .Where(w => w.DtDeletedAt == null)
            .Include(w => w.WindTurbineType)
            .FirstOrDefaultAsync(w => w.IdWindTurbine == id) 
            ?? throw new Exception("Turbina Eólica não encontrado ou desativado!");

        try
        {
            var windTurbineDTO = new WindTurbineDetailedDTO
            {
                IdWindTurbine = id,
                DsMaterial = windTurbine.DsMaterial,
                DsSize = windTurbine.DsSize,
                DsPrice = windTurbine.DsPrice,
                WindTurbineTypeDTO = windTurbine.WindTurbineType != null ? new WindTurbineTypeDetailedDTO
                {
                    IdWindTurbineType = windTurbine.WindTurbineType.IdWindTurbineType,
                    DsVoltage = windTurbine.WindTurbineType.DsVoltage,
                    DsModel = windTurbine.WindTurbineType.DsModel,
                    DsManufacturer = windTurbine.WindTurbineType.DsManufacturer,
                    DsGeneratorType = windTurbine.WindTurbineType.DsGeneratorType,
                    DsWarrantyYears = windTurbine.WindTurbineType.DsWarrantyYears
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
