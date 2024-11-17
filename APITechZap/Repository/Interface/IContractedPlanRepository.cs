using APITechZap.Models;

namespace APITechZap.Repository.Interface;

public interface IContractedPlanRepository
{
    Task<IEnumerable<ContractedPlan>> GetAllContractedPlansAsync();
    Task<ContractedPlan> GetContractedPlanByIdAsync(int id);
    Task <string> AddContractedPlanAsync(ContractedPlan contractedPlan);
    Task <string> UpdateContractedPlanAsync(ContractedPlan contractedPlan);
    Task <string> DeleteContractedPlanAsync(int id);
}
