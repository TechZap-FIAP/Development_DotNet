using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Models.DTOs;
using APITechZap.Models.DTOs.SolarPanelDTOs;
using APITechZap.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace APITechZap.Repository;

/// <summary>
/// Solar Panel Repository
/// </summary>
public class SolarPanelRepository : ISolarPanelRepository
{

    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Constructor for SolarPanelRepository
    /// </summary>
    /// <param name="dbContext"></param>
    public SolarPanelRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Adiciona o Painel Solar
    /// </summary>
    /// <param name="solarPanelDTO"></param>
    /// <returns></returns>
    public async Task<string> AddSolarPanelAsync(SolarPanelDTO solarPanelDTO)
    {
        if (solarPanelDTO == null)
        {
            throw new Exception("Campos vazios, preencha-os");
        }

        var solarPanel = new SolarPanel
        {
            DsMaterial = solarPanelDTO.DsMaterial,
            DsSize = solarPanelDTO.DsSize,
            DsPrice = solarPanelDTO.DsPrice
        };

        try
        {
            await _dbContext.SolarPanels.AddAsync(solarPanel);
            await _dbContext.SaveChangesAsync();

            return "Painel Solar Adicionado com Sucesso";
        }
        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro ao adicionar o painel solar", ex);
        }
    }

    /// <summary>
    /// Adiciona o Tipo de Painel Solar
    /// </summary>
    /// <param name="solarPanelId"></param>
    /// <param name="solarPanelTypeDTO"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> AddSolarPanelTypeAsync(int solarPanelId, SolarPanelTypeDTO solarPanelTypeDTO)
    {
        var solarPanel = await _dbContext.SolarPanels
            .Include(s => s.SolarPanelType)
            .FirstOrDefaultAsync(s => s.IdSolarPanel == solarPanelId && s.DtDeletedAt == null) 
            ?? throw new Exception("Painel Solar não encontrado!");

        var solarPanelType = new SolarPanelType
        {
            DsVoltage = solarPanelTypeDTO.DsVoltage,
            DsModel = solarPanelTypeDTO.DsModel,
            DsManufacturer = solarPanelTypeDTO.DsManufacturer,
            DsCellType = solarPanelTypeDTO.DsCellType,
            DsCostPerWatts = solarPanelTypeDTO.DsCostPerWatts,
            DsProductWarranty = solarPanelTypeDTO.DsProductWarranty,
            IdSolarPanel = solarPanel.IdSolarPanel
        };

        try
        {
            await _dbContext.SolarPanelTypes.AddAsync(solarPanelType);
            await _dbContext.SaveChangesAsync();

            return "Tipo de Painel Solar Adicionado com Sucesso";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// Get all Solar Panels
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<IEnumerable<SolarPanelDetailedDTO>> GetAllSolarPanelsAsync()
    {
        var solarPanels = await _dbContext.SolarPanels
            .Where(s => s.DtDeletedAt == null)
            .Include(s => s.SolarPanelType)
            .ToListAsync() ?? throw new Exception("Painéis Solares não encontrados!");

        try
        {
            var solarPanelDTOs = solarPanels.Select(s => new SolarPanelDetailedDTO
            {
                IdSolarPanel = s.IdSolarPanel,
                DsMaterial = s.DsMaterial,
                DsSize = s.DsSize,
                DsPrice = s.DsPrice,
                SolarPanelTypeDTO = s.SolarPanelType != null ? new SolarPanelTypeDetailedDTO
                {
                    IdSolarPanelType = s.SolarPanelType.IdSolarPanelType,
                    DsVoltage = s.SolarPanelType.DsVoltage,
                    DsModel = s.SolarPanelType.DsModel,
                    DsManufacturer = s.SolarPanelType.DsManufacturer,
                    DsCellType = s.SolarPanelType.DsCellType,
                    DsCostPerWatts = s.SolarPanelType.DsCostPerWatts,
                    DsProductWarranty = s.SolarPanelType.DsProductWarranty
                } : null
            });

            return solarPanelDTOs;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar Painéis Solares!", ex);
        }
    }

    /// <summary>
    /// Get Solar Panel by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<SolarPanelDetailedDTO> GetSolarPanelByIdAsync(int id)
    {
        var solarPanel = await _dbContext.SolarPanels.Include(s => s.SolarPanelType).FirstOrDefaultAsync(s => s.IdSolarPanel == id) ?? throw new Exception("Painel Solar não encontrado ou desativado!");

        try
        {
            var solarPanelDTO = new SolarPanelDetailedDTO
            {
                IdSolarPanel = id,
                DsMaterial = solarPanel.DsMaterial,
                DsSize = solarPanel.DsSize,
                DsPrice = solarPanel.DsPrice,
                SolarPanelTypeDTO = solarPanel.SolarPanelType != null ? new SolarPanelTypeDetailedDTO
                {
                    IdSolarPanelType = solarPanel.SolarPanelType.IdSolarPanelType,
                    DsVoltage = solarPanel.SolarPanelType.DsVoltage,
                    DsModel = solarPanel.SolarPanelType.DsModel,
                    DsManufacturer = solarPanel.SolarPanelType.DsManufacturer,
                    DsCellType = solarPanel.SolarPanelType.DsCellType,
                    DsCostPerWatts = solarPanel.SolarPanelType.DsCostPerWatts,
                    DsProductWarranty = solarPanel.SolarPanelType.DsProductWarranty
                } : null
            };

            return solarPanelDTO;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar o Painel Solar!", ex);
        }
    }

}
