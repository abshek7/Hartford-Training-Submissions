using InsuranceManagementApi.Data;
using InsuranceManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementApi.Repositories;

public class PolicyRepository : IPolicyRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PolicyRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Policy> CreatePolicyAsync(Policy policy)
    {
        _dbContext.Policies.Add(policy);
        await _dbContext.SaveChangesAsync();

        return policy;
    }

    public async Task<Policy?> GetPolicyByIdAsync(int policyId)
    {
        return await _dbContext.Policies
            .FirstOrDefaultAsync(p => p.PolicyId == policyId);
    }

    public async Task UpdatePolicyAsync(Policy policy)
    {
        _dbContext.Policies.Update(policy);
        await _dbContext.SaveChangesAsync();
    }
}