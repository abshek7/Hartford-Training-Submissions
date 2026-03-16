using InsuranceManagementApi.Models;

namespace InsuranceManagementApi.Services;

public interface IPolicyService
{
    Task<Policy?> CreatePolicyAsync(string policyType, decimal premiumAmount, DateTime startDate, DateTime endDate, int customerId);
    Task<bool> UpdatePolicyPremiumAsync(int policyId, decimal premiumAmount);
    Task<Policy?> GetPolicyByIdAsync(int policyId);
}
