using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Models.DTOs.ContractedPlanDTOs;
using APITechZap.Models.DTOs.SolarPanelDTOs;
using APITechZap.Models.DTOs.WindTurbineDTOs;
using APITechZap.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace APITechZap.Repository;

/// <summary>
/// Classe de repositório para os planos contratados
/// </summary>
public class ContractedPlanRepository : IContractedPlanRepository
{
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Construtor da classe que recebe o contexto do banco de dados
    /// </summary>
    /// <param name="dbContext"></param>
    public ContractedPlanRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Adiciona um plano contratado ao banco de dados
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="plan"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> AddContractedPlanAsync(int userId, ContractedPlan plan)
    {
        // Verifica se o usuário existe
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.IdUser == userId && u.DtDeletedAt == null)
            ?? throw new Exception("Usuário não encontrado.");

        // Atribui o usuário ao plano
        plan.IdUser = userId;
        plan.DtCreatedAt = DateTime.Now;

        // Verifica se existe um painel solar associado
        if (plan.IdSolarPanel.HasValue)
        {
            var solarPanel = await _dbContext.SolarPanels
                .FirstOrDefaultAsync(sp => sp.IdSolarPanel == plan.IdSolarPanel) ??
                throw new Exception("Painel solar especificado não encontrado.");
        }

        // Verifica se existe uma turbina eólica associada
        if (plan.IdWindTurbine.HasValue)
        {
            var windTurbine = await _dbContext.WindTurbines
                .FirstOrDefaultAsync(wt => wt.IdWindTurbine == plan.IdWindTurbine) ?? 
                throw new Exception("Turbina eólica especificada não encontrada.");
        }

        // Adiciona o plano ao banco de dados
        await _dbContext.ContractedPlans.AddAsync(plan);
        await _dbContext.SaveChangesAsync();

        return "Plano contratado com sucesso!";
    }

    /// <summary>
    /// Retorna os planos contratados por um usuário pelo id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<IEnumerable<ContractedPlanDetailedDTO>> GetPlansByUserIdAsync(int userId)
    {
        var plans = await _dbContext.ContractedPlans
        .Where(cp => cp.IdUser == userId && cp.DtDeletedAt == null)
        .ToListAsync() ?? throw new Exception("Planos não encontrados!"); ;


        try
        {
            // Mapeando os dados para DTOs
            var planDTOs = plans.Select(plan => new ContractedPlanDetailedDTO
            {
                SolarPanel = plan.SolarPanel != null ? new SolarPanelDetailedDTO
                {
                    IdSolarPanel = plan.SolarPanel.IdSolarPanel,
                    DsMaterial = plan.SolarPanel.DsMaterial,
                    DsSize = plan.SolarPanel.DsSize,
                    DsPrice = plan.SolarPanel.DsPrice,
                    SolarPanelTypeDTO = plan.SolarPanel.SolarPanelType != null ? new SolarPanelTypeDetailedDTO
                    {
                        IdSolarPanelType = plan.SolarPanel.SolarPanelType.IdSolarPanelType,
                        DsVoltage = plan.SolarPanel.SolarPanelType.DsVoltage,
                        DsModel = plan.SolarPanel.SolarPanelType.DsModel,
                        DsManufacturer = plan.SolarPanel.SolarPanelType.DsManufacturer,
                        DsCellType = plan.SolarPanel.SolarPanelType.DsCellType,
                        DsCostPerWatts = plan.SolarPanel.SolarPanelType.DsCostPerWatts,
                        DsProductWarranty = plan.SolarPanel.SolarPanelType.DsProductWarranty
                    } : null
                } : null,
                WindTurbine = plan.WindTurbine != null ? new WindTurbineDetailedDTO
                {
                    IdWindTurbine = plan.WindTurbine.IdWindTurbine,
                    DsMaterial = plan.WindTurbine.DsMaterial,
                    DsSize = plan.WindTurbine.DsSize,
                    DsPrice = plan.WindTurbine.DsPrice,
                    WindTurbineTypeDTO = plan.WindTurbine.WindTurbineType != null ? new WindTurbineTypeDetailedDTO
                    {
                        IdWindTurbineType = plan.WindTurbine.WindTurbineType.IdWindTurbineType,
                        DsVoltage = plan.WindTurbine.WindTurbineType.DsVoltage,
                        DsModel = plan.WindTurbine.WindTurbineType.DsModel,
                        DsManufacturer = plan.WindTurbine.WindTurbineType.DsManufacturer,
                        DsGeneratorType = plan.WindTurbine.WindTurbineType.DsGeneratorType,
                        DsWarrantyYears = plan.WindTurbine.WindTurbineType.DsWarrantyYears,
                    } : null
                }:null
            });

            return planDTOs;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar os planos. ", ex);
        }
    }

    /// <summary>
    /// Exclui um plano contratado pelo ID
    /// </summary>
    /// <param name="IdPlan"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> DeleteContractedPlanAsync(int IdPlan)
    {
        var plan = await _dbContext.ContractedPlans.FirstOrDefaultAsync(cp => cp.IdContractedPlan == IdPlan);
        if (plan != null)
        {
            plan.DtDeletedAt = DateTime.Now;
            _dbContext.ContractedPlans.Update(plan);
            await _dbContext.SaveChangesAsync();
            return "O Plano foi desativado com sucesso!";
        }
        throw new Exception("Plano não encontrado ou já Desativado!");
    }
}
