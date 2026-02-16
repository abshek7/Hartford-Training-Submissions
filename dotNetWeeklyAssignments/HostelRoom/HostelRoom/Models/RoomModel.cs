using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostelRoom.Models
{
    public class RoomModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomNumber { get; set; } = string.Empty;

        [Range(1, 6)]
        public int Capacity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        [ForeignKey("Hostel")]
        [Required]
        public long HostelId { get; set; }
        public HostelModel? Hostel { get; set; }
    }
}
