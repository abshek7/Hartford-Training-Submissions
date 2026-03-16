using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementApi.Data;
using InsuranceManagementApi.DTOs;
using InsuranceManagementApi.Models;
using InsuranceManagementApi.Services;

namespace InsuranceManagementApi.Controllers;

/// <summary>
/// Controller responsible for managing customers.
/// </summary>
[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    /// <summary>
    /// Constructor injection for customer service.
    /// </summary>
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    /// <summary>
    /// API 1: Create a new customer.
    /// Endpoint: POST /api/customers
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
    {
        var customer = await _customerService.CreateCustomerAsync(request.Name, request.Email, request.Phone, request.Address);

        return Created("", new
        {
            customerId = customer.CustomerId,
            message = "Customer created successfully"
        });
    }

    /// <summary>
    /// API 3: Get policies for a specific customer.
    /// Endpoint: GET /api/customers/{customerId}/policies
    /// </summary>
    [HttpGet("{customerId}/policies")]
    public async Task<IActionResult> GetPoliciesByCustomer(int customerId)
    {
        // Fetch policies belonging to the customer
        var policies = await _customerService.GetPoliciesByCustomerAsync(customerId);

        var response = policies.Select(p => new
        {
            p.PolicyId,
            p.PolicyType,
            p.PremiumAmount
        });

        return Ok(response);
    }
}