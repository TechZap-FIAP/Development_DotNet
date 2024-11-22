using APITechZap.Models;
using APITechZap.Models.DTOs.ContractedPlanDTOs;

namespace APITechZap.Repository.Interface;

/// <summary>
/// Interface de repositório para os planos contratados
/// </summary>
public interface IContractedPlanRepository
{
    /// <summary>
    /// Adiciona um novo plano contratado
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="plan"></param>
    /// <returns></returns>
    Task<string> AddContractedPlanAsync(int userId, ContractedPlan plan);

    /// <summary>
    /// Retorna todos os planos contratados de um usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<IEnumerable<ContractedPlanDetailedDTO>> GetPlansByUserIdAsync(int userId);

    /// <summary>
    /// Exclui um plano contratado pelo ID
    /// </summary>
    /// <param name="planId"></param>
    /// <returns></returns>
    Task<string> DeleteContractedPlanAsync(int planId);
}
