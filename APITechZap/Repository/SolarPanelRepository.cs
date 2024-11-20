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
    /// Get all Solar Panels
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<IEnumerable<SolarPanelDTO>> GetAllSolarPanelsAsync()
    {
        var solarPanels = await _dbContext.SolarPanels.Include(s => s.SolarPanelType).ToListAsync() ?? throw new Exception("Painéis Solares não encontrados!");

        try
        {
            var solarPanelDTOs = solarPanels.Select(s => new SolarPanelDTO
            {
                DsMaterial = s.DsMaterial,
                DsSize = s.DsSize,
                DsPrice = s.DsPrice,
                SolarPanelTypeDTO = s.SolarPanelType != null ? new SolarPanelTypeDTO
                {
                    DsVoltage = s.SolarPanelType.DsVoltage,
                    DsModel = s.SolarPanelType.DsModel,
                    DsManufacturer = s.SolarPanelType.DsManufacturer,
                    DsCellType = s.SolarPanelType.DsCellType,
                    DsCostPerWatts = s.SolarPanelType.DsCostPerWatts,
                    DsProductWarranty = s.SolarPanelType.DsProductWarranty,
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
    public async Task<SolarPanelDTO> GetSolarPanelByIdAsync(int id)
    {
        var solarPanel = await _dbContext.SolarPanels.Include(s => s.SolarPanelType).FirstOrDefaultAsync(s => s.IdSolarPanel == id) ?? throw new Exception("Painel Solar não encontrado ou desativado!");

        try
        {
            var solarPanelDTO = new SolarPanelDTO
            {
                DsMaterial = solarPanel.DsMaterial,
                DsSize = solarPanel.DsSize,
                DsPrice = solarPanel.DsPrice,
                SolarPanelTypeDTO = solarPanel.SolarPanelType != null ? new SolarPanelTypeDTO
                {
                    DsVoltage = solarPanel.SolarPanelType.DsVoltage,
                    DsModel = solarPanel.SolarPanelType.DsModel,
                    DsManufacturer = solarPanel.SolarPanelType.DsManufacturer,
                    DsCellType = solarPanel.SolarPanelType.DsCellType,
                    DsCostPerWatts = solarPanel.SolarPanelType.DsCostPerWatts,
                    DsProductWarranty = solarPanel.SolarPanelType.DsProductWarranty,
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
