using InsuranceManagementApi.Models;

namespace InsuranceManagementApi.Repositories;

public interface IClaimRepository
{
    Task<Claim> CreateClaimAsync(Claim claim);
    Task<Claim?> GetClaimByIdAsync(int claimId);
    Task UpdateClaimAsync(Claim claim);
}