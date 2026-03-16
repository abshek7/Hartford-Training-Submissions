using InsuranceManagementApi.Models;

namespace InsuranceManagementApi.Services;

public interface ICustomerService
{
    Task<Customer> CreateCustomerAsync(string name, string email, string phone, string address);
    Task<List<Policy>> GetPoliciesByCustomerAsync(int customerId);
    Task<bool> CustomerExistsAsync(int customerId);
}
