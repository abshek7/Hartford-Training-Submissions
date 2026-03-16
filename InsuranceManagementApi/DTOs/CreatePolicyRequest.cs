using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementApi.DTOs;

public class CreatePolicyRequest : IValidatableObject
{
    [Required(ErrorMessage = "PolicyType is required.")]
    [StringLength(50, ErrorMessage = "PolicyType cannot exceed 50 characters.")]
    public string PolicyType { get; set; } = string.Empty;

    [Range(1, (double)decimal.MaxValue, ErrorMessage = "PremiumAmount must be greater than 0.")]
    public decimal PremiumAmount { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "CustomerId must be a valid ID.")]
    public int CustomerId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndDate <= StartDate)
        {
            yield return new ValidationResult("EndDate must be strictly greater than StartDate.", new[] { nameof(EndDate) });
        }
    }
}