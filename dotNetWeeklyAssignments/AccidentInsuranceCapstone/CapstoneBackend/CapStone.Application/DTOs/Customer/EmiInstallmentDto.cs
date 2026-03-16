namespace CapStone.Application.DTOs.Customer
{
    public class EmiInstallmentDto
    {
        public Guid PolicyId { get; set; }
        public int InstallmentNumber { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal RemainingAmount { get; set; }
        public string Status { get; set; } = "Unpaid";
        public bool IsPaid => Status == "Paid";
    }
}

