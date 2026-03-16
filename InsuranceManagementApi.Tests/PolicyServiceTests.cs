using Moq;
using Xunit;
using InsuranceManagementApi.Models;
using InsuranceManagementApi.Repositories;
using InsuranceManagementApi.Services;
using InsuranceManagementApi.Exceptions;

namespace InsuranceManagementApi.Tests;

public class PolicyServiceTests
{
    private readonly Mock<IPolicyRepository> _mockPolicyRepo;
    private readonly Mock<ICustomerRepository> _mockCustomerRepo;
    private readonly PolicyService _policyService;

    public PolicyServiceTests()
    {
        _mockPolicyRepo = new Mock<IPolicyRepository>();
        _mockCustomerRepo = new Mock<ICustomerRepository>();
        _policyService = new PolicyService(_mockPolicyRepo.Object, _mockCustomerRepo.Object);
    }

    [Fact]
    public async Task CreatePolicyAsync_CustomerExists_ShouldReturnPolicy()
    {
        // Arrange
        var customerId = 1;
        _mockCustomerRepo.Setup(repo => repo.CustomerExistsAsync(customerId)).ReturnsAsync(true);
        _mockPolicyRepo.Setup(repo => repo.CreatePolicyAsync(It.IsAny<Policy>()))
            .ReturnsAsync((Policy p) => {
                p.PolicyId = 100;
                return p;
            });

        // Act
        var result = await _policyService.CreatePolicyAsync("Health", 500, DateTime.Now, DateTime.Now.AddYears(1), customerId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(100, result.PolicyId);
    }

    [Fact]
    public async Task CreatePolicyAsync_CustomerDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        var customerId = 99;
        _mockCustomerRepo.Setup(repo => repo.CustomerExistsAsync(customerId)).ReturnsAsync(false);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _policyService.CreatePolicyAsync("Health", 500, DateTime.Now, DateTime.Now.AddYears(1), customerId));
    }

    [Fact]
    public async Task UpdatePolicyPremiumAsync_PolicyExists_ShouldUpdateAndReturnTrue()
    {
        // Arrange
        var policyId = 100;
        var policy = new Policy { PolicyId = policyId, PremiumAmount = 500 };
        _mockPolicyRepo.Setup(repo => repo.GetPolicyByIdAsync(policyId)).ReturnsAsync(policy);

        // Act
        var result = await _policyService.UpdatePolicyPremiumAsync(policyId, 600);

        // Assert
        Assert.True(result);
        Assert.Equal(600, policy.PremiumAmount);
        _mockPolicyRepo.Verify(repo => repo.UpdatePolicyAsync(policy), Times.Once);
    }

    [Fact]
    public async Task UpdatePolicyPremiumAsync_PolicyDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        var policyId = 999;
        _mockPolicyRepo.Setup(repo => repo.GetPolicyByIdAsync(policyId)).ReturnsAsync((Policy?)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _policyService.UpdatePolicyPremiumAsync(policyId, 600));
    }
}
