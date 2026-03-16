namespace InsuranceManagementApi.Models;

public class Policy
{
    public int PolicyId { get; set; }

    public string PolicyType { get; set; } = string.Empty;

    public decimal PremiumAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int CustomerId { get; set; }

    public Customer? Customer { get; set; }
}