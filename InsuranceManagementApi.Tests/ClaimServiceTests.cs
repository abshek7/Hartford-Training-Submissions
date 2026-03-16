using Moq;
using Xunit;
using InsuranceManagementApi.Models;
using InsuranceManagementApi.Repositories;
using InsuranceManagementApi.Services;
using InsuranceManagementApi.Exceptions;

namespace InsuranceManagementApi.Tests;

public class ClaimServiceTests
{
    private readonly Mock<IClaimRepository> _mockClaimRepo;
    private readonly Mock<IPolicyRepository> _mockPolicyRepo;
    private readonly ClaimService _claimService;

    public ClaimServiceTests()
    {
        _mockClaimRepo = new Mock<IClaimRepository>();
        _mockPolicyRepo = new Mock<IPolicyRepository>();
        _claimService = new ClaimService(_mockClaimRepo.Object, _mockPolicyRepo.Object);
    }

    [Fact]
    public async Task SubmitClaimAsync_PolicyExists_ShouldReturnClaim()
    {
        // Arrange
        var policyId = 100;
        _mockPolicyRepo.Setup(repo => repo.GetPolicyByIdAsync(policyId))
            .ReturnsAsync(new Policy { PolicyId = policyId });
            
        _mockClaimRepo.Setup(repo => repo.CreateClaimAsync(It.IsAny<Claim>()))
            .ReturnsAsync((Claim c) => {
                c.ClaimId = 50;
                return c;
            });

        // Act
        var result = await _claimService.SubmitClaimAsync(policyId, 1500, DateTime.Now);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(50, result.ClaimId);
        Assert.Equal("Submitted", result.Status);
    }

    [Fact]
    public async Task SubmitClaimAsync_PolicyDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        var policyId = 999;
        _mockPolicyRepo.Setup(repo => repo.GetPolicyByIdAsync(policyId)).ReturnsAsync((Policy?)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _claimService.SubmitClaimAsync(policyId, 1500, DateTime.Now));
    }

    [Fact]
    public async Task UpdateClaimStatusAsync_ClaimExists_ShouldUpdateAndReturnTrue()
    {
        // Arrange
        var claimId = 50;
        var claim = new Claim { ClaimId = claimId, Status = "Submitted" };
        _mockClaimRepo.Setup(repo => repo.GetClaimByIdAsync(claimId)).ReturnsAsync(claim);

        // Act
        var result = await _claimService.UpdateClaimStatusAsync(claimId, "Approved");

        // Assert
        Assert.True(result);
        Assert.Equal("Approved", claim.Status);
        _mockClaimRepo.Verify(repo => repo.UpdateClaimAsync(claim), Times.Once);
    }

    [Fact]
    public async Task UpdateClaimStatusAsync_ClaimDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        var claimId = 999;
        _mockClaimRepo.Setup(repo => repo.GetClaimByIdAsync(claimId)).ReturnsAsync((Claim?)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _claimService.UpdateClaimStatusAsync(claimId, "Approved"));
    }
}
