using InsuranceManagementApi.Exceptions;
using InsuranceManagementApi.Models;
using InsuranceManagementApi.Repositories;

namespace InsuranceManagementApi.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> CreateCustomerAsync(string name, string email, string phone, string address)
    {
        var customer = new Customer
        {
            Name = name,
            Email = email,
            Phone = phone,
            Address = address
        };

        return await _customerRepository.CreateCustomerAsync(customer);
    }

    public async Task<List<Policy>> GetPoliciesByCustomerAsync(int customerId)
    {
        if (!await CustomerExistsAsync(customerId))
        {
            throw new NotFoundException($"Customer with ID {customerId} not found.");
        }
        return await _customerRepository.GetPoliciesByCustomerAsync(customerId);
    }

    public async Task<bool> CustomerExistsAsync(int customerId)
    {
        return await _customerRepository.CustomerExistsAsync(customerId);
    }
}
