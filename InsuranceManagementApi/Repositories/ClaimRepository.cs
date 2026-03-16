using InsuranceManagementApi.Data;
using InsuranceManagementApi.Models;

namespace InsuranceManagementApi.Repositories;

public class ClaimRepository : IClaimRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ClaimRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Claim> CreateClaimAsync(Claim claim)
    {
        _dbContext.Claims.Add(claim);
        await _dbContext.SaveChangesAsync();

        return claim;
    }

    public async Task<Claim?> GetClaimByIdAsync(int claimId)
    {
        return await _dbContext.Claims.FindAsync(claimId);
    }

    public async Task UpdateClaimAsync(Claim claim)
    {
        _dbContext.Claims.Update(claim);
        await _dbContext.SaveChangesAsync();
    }
}