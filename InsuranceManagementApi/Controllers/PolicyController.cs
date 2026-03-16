using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementApi.Data;
using InsuranceManagementApi.DTOs;
using InsuranceManagementApi.Models;
using InsuranceManagementApi.Services;

namespace InsuranceManagementApi.Controllers;

/// <summary>
/// Controller responsible for managing insurance policies.
/// </summary>
[ApiController]
[Route("api/policies")]
public class PolicyController : ControllerBase
{
    private readonly IPolicyService _policyService;

    public PolicyController(IPolicyService policyService)
    {
        _policyService = policyService;
    }

    /// <summary>
    /// API 2: Create insurance policy
    /// Endpoint: POST /api/policies
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreatePolicy(CreatePolicyRequest request)
    {
        var policy = await _policyService.CreatePolicyAsync(request.PolicyType, request.PremiumAmount, request.StartDate, request.EndDate, request.CustomerId);
        return Ok(new
        {
            policyId = policy.PolicyId,
            message = "Policy created successfully"
        });
    }

    /// <summary>
    /// API 4: Update policy premium
    /// Endpoint: PUT /api/policies/{policyId}
    /// </summary>
    [HttpPut("{policyId}")]
    public async Task<IActionResult> UpdatePolicy(int policyId, [FromBody] decimal premiumAmount)
    {
        var result = await _policyService.UpdatePolicyPremiumAsync(policyId, premiumAmount);
        return Ok(new
        {
            message = "Policy updated successfully"
        });
    }

    /// <summary>
    /// Bonus API: Get policy by ID
    /// Endpoint: GET /api/policies/{policyId}
    /// </summary>
    [HttpGet("{policyId}")]
    public async Task<IActionResult> GetPolicy(int policyId)
    {
        var policy = await _policyService.GetPolicyByIdAsync(policyId);
        var response = new
        {
            policy.PolicyId,
            policy.PolicyType,
            policy.PremiumAmount,
            policy.StartDate,
            policy.EndDate
        };

        return Ok(response);
    }
}