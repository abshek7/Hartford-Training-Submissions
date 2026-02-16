using System.ComponentModel.DataAnnotations;

namespace HostelRoom.Models
{
    public class HostelModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string HostelName { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Address { get; set; }
         
        public ICollection<RoomModel>? Rooms { get; set; }
    }
}
