using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementApi.DTOs;

public class SubmitClaimRequest : IValidatableObject
{
    [Range(1, int.MaxValue, ErrorMessage = "PolicyId must be a valid ID.")]
    public int PolicyId { get; set; }

    [Range(1, (double)decimal.MaxValue, ErrorMessage = "ClaimAmount must be greater than 0.")]
    public decimal ClaimAmount { get; set; }

    [Required]
    public DateTime ClaimDate { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ClaimDate > DateTime.UtcNow)
        {
            yield return new ValidationResult("ClaimDate cannot be in the future.", new[] { nameof(ClaimDate) });
        }
    }
}