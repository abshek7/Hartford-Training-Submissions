using InsuranceManagementApi.Models;

namespace InsuranceManagementApi.Repositories;

public interface ICustomerRepository
{
    Task<Customer> CreateCustomerAsync(Customer customer);

    Task<bool> CustomerExistsAsync(int customerId);

    Task<List<Policy>> GetPoliciesByCustomerAsync(int customerId);
}