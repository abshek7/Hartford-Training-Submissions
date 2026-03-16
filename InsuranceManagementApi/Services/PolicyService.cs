using InsuranceManagementApi.Exceptions;
using InsuranceManagementApi.Models;
using InsuranceManagementApi.Repositories;

namespace InsuranceManagementApi.Services;

public class PolicyService : IPolicyService
{
    private readonly IPolicyRepository _policyRepository;
    private readonly ICustomerRepository _customerRepository;

    public PolicyService(IPolicyRepository policyRepository, ICustomerRepository customerRepository)
    {
        _policyRepository = policyRepository;
        _customerRepository = customerRepository;
    }

    public async Task<Policy?> CreatePolicyAsync(string policyType, decimal premiumAmount, DateTime startDate, DateTime endDate, int customerId)
    {
        var customerExists = await _customerRepository.CustomerExistsAsync(customerId);
        if (!customerExists)
        {
            throw new NotFoundException($"Customer with ID {customerId} not found.");
        }

        var policy = new Policy
        {
            PolicyType = policyType,
            PremiumAmount = premiumAmount,
            StartDate = startDate,
            EndDate = endDate,
            CustomerId = customerId
        };

        return await _policyRepository.CreatePolicyAsync(policy);
    }

    public async Task<bool> UpdatePolicyPremiumAsync(int policyId, decimal premiumAmount)
    {
        var policy = await _policyRepository.GetPolicyByIdAsync(policyId);
        if (policy == null)
        {
            throw new NotFoundException($"Policy with ID {policyId} not found.");
        }

        policy.PremiumAmount = premiumAmount;
        await _policyRepository.UpdatePolicyAsync(policy);
        return true;
    }

    public async Task<Policy?> GetPolicyByIdAsync(int policyId)
    {
        var policy = await _policyRepository.GetPolicyByIdAsync(policyId);
        if (policy == null)
        {
            throw new NotFoundException($"Policy with ID {policyId} not found.");
        }
        return policy;
    }
}
