using InsuranceManagementApi.Exceptions;
using InsuranceManagementApi.Models;
using InsuranceManagementApi.Repositories;

namespace InsuranceManagementApi.Services;

public class ClaimService : IClaimService
{
    private readonly IClaimRepository _claimRepository;
    private readonly IPolicyRepository _policyRepository;

    public ClaimService(IClaimRepository claimRepository, IPolicyRepository policyRepository)
    {
        _claimRepository = claimRepository;
        _policyRepository = policyRepository;
    }

    public async Task<Claim?> SubmitClaimAsync(int policyId, decimal claimAmount, DateTime claimDate)
    {
        var policy = await _policyRepository.GetPolicyByIdAsync(policyId);
        if (policy == null)
        {
            throw new NotFoundException($"Policy with ID {policyId} not found.");
        }

        var claim = new Claim
        {
            PolicyId = policyId,
            ClaimAmount = claimAmount,
            ClaimDate = claimDate,
            Status = "Submitted"
        };

        return await _claimRepository.CreateClaimAsync(claim);
    }

    public async Task<bool> UpdateClaimStatusAsync(int claimId, string status)
    {
        var claim = await _claimRepository.GetClaimByIdAsync(claimId);
        if (claim == null)
        {
            throw new NotFoundException($"Claim with ID {claimId} not found.");
        }

        claim.Status = status;
        await _claimRepository.UpdateClaimAsync(claim);
        return true;
    }
}
