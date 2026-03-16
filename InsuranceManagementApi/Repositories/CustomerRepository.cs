using InsuranceManagementApi.Data;
using InsuranceManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementApi.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CustomerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();

        return customer;
    }

    public async Task<bool> CustomerExistsAsync(int customerId)
    {
        return await _dbContext.Customers
            .AnyAsync(c => c.CustomerId == customerId);
    }

    public async Task<List<Policy>> GetPoliciesByCustomerAsync(int customerId)
    {
        return await _dbContext.Policies
            .Where(p => p.CustomerId == customerId)
            .ToListAsync();
    }
}