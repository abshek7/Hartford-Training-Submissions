using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementApi.DTOs;

public class CreateCustomerRequest
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email format.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
    public string Phone { get; set; } = string.Empty;

    [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
    public string Address { get; set; } = string.Empty;
}