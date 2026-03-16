using InsuranceManagementApi.Models;

namespace InsuranceManagementApi.Repositories;

public interface IPolicyRepository
{
    Task<Policy> CreatePolicyAsync(Policy policy);

    Task<Policy?> GetPolicyByIdAsync(int policyId);

    Task UpdatePolicyAsync(Policy policy);
}