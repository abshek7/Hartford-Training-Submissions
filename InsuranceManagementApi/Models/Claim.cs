namespace InsuranceManagementApi.Models;

public class Claim
{
    public int ClaimId { get; set; }

    public int PolicyId { get; set; }

    public decimal ClaimAmount { get; set; }

    public DateTime ClaimDate { get; set; }

    public string Status { get; set; } = "Submitted";
}