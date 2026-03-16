using InsuranceManagementApi.Models;

namespace InsuranceManagementApi.Services;

public interface IClaimService
{
    Task<Claim?> SubmitClaimAsync(int policyId, decimal claimAmount, DateTime claimDate);
    Task<bool> UpdateClaimStatusAsync(int claimId, string status);
}
