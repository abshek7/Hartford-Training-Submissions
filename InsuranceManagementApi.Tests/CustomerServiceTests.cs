using Moq;
using Xunit;
using InsuranceManagementApi.Models;
using InsuranceManagementApi.Repositories;
using InsuranceManagementApi.Services;
using InsuranceManagementApi.Exceptions;

namespace InsuranceManagementApi.Tests;

public class CustomerServiceTests
{
    private readonly Mock<ICustomerRepository> _mockCustomerRepo;
    private readonly CustomerService _customerService;

    public CustomerServiceTests()
    {
        _mockCustomerRepo = new Mock<ICustomerRepository>();
        _customerService = new CustomerService(_mockCustomerRepo.Object);
    }

    [Fact]
    public async Task CreateCustomerAsync_ShouldReturnCreatedCustomer()
    {
        // Arrange
        var name = "John Doe";
        var email = "john@example.com";
        var phone = "1234567890";
        var address = "123 Main St";

        _mockCustomerRepo.Setup(repo => repo.CreateCustomerAsync(It.IsAny<Customer>()))
            .ReturnsAsync((Customer c) => {
                c.CustomerId = 1;
                return c;
            });

        // Act
        var result = await _customerService.CreateCustomerAsync(name, email, phone, address);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.CustomerId);
        Assert.Equal(name, result.Name);
        Assert.Equal(email, result.Email);
    }

    [Fact]
    public async Task GetPoliciesByCustomerAsync_ExistingCustomer_ShouldReturnPolicies()
    {
        // Arrange
        var customerId = 1;
        var policies = new List<Policy>
        {
            new Policy { PolicyId = 1, PolicyType = "Life" }
        };

        _mockCustomerRepo.Setup(repo => repo.CustomerExistsAsync(customerId)).ReturnsAsync(true);
        _mockCustomerRepo.Setup(repo => repo.GetPoliciesByCustomerAsync(customerId))
            .ReturnsAsync(policies);

        // Act
        var result = await _customerService.GetPoliciesByCustomerAsync(customerId);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(1, result.First().PolicyId);
    }

    [Fact]
    public async Task GetPoliciesByCustomerAsync_NonExistingCustomer_ShouldThrowNotFoundException()
    {
        // Arrange
        var customerId = 99;
        _mockCustomerRepo.Setup(repo => repo.CustomerExistsAsync(customerId)).ReturnsAsync(false);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _customerService.GetPoliciesByCustomerAsync(customerId));
    }
}
