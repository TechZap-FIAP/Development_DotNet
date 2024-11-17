using APITechZap.Models;
using APITechZap.Repository.Interface;

namespace APITechZap.Repository;

public class ContractedPlanRepository : IContractedPlanRepository
{
    public Task<string> AddContractedPlanAsync(ContractedPlan contractedPlan)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteContractedPlanAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ContractedPlan>> GetAllContractedPlansAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ContractedPlan> GetContractedPlanByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateContractedPlanAsync(ContractedPlan contractedPlan)
    {
        throw new NotImplementedException();
    }
}
