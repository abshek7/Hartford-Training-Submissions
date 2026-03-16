using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementApi.Data;
using InsuranceManagementApi.DTOs;
using InsuranceManagementApi.Models;
using InsuranceManagementApi.Services;

namespace InsuranceManagementApi.Controllers;

/// <summary>
/// Controller responsible for handling insurance claims.
/// </summary>
[ApiController]
[Route("api/claims")]
public class ClaimController : ControllerBase
{
    private readonly IClaimService _claimService;

    public ClaimController(IClaimService claimService)
    {
        _claimService = claimService;
    }

    /// <summary>
    /// API 5: Submit insurance claim
    /// Endpoint: POST /api/claims
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> SubmitClaim(SubmitClaimRequest request)
    {
        var claim = await _claimService.SubmitClaimAsync(request.PolicyId, request.ClaimAmount, request.ClaimDate);
        return Ok(new
        {
            claimId = claim.ClaimId,
            status = claim.Status
        });
    }

    /// <summary>
    /// Bonus API: Update claim status
    /// Endpoint: PUT /api/claims/{claimId}
    /// </summary>
    [HttpPut("{claimId}")]
    public async Task<IActionResult> UpdateClaimStatus(int claimId, [FromBody] string status)
    {
        var result = await _claimService.UpdateClaimStatusAsync(claimId, status);
        return Ok(new
        {
            message = "Claim status updated successfully"
        });
    }
}