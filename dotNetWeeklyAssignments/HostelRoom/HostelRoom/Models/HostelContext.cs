using Microsoft.EntityFrameworkCore;

namespace HostelRoom.Models
{
    public class HostelContext:DbContext
    {
        public HostelContext(DbContextOptions options) : base(options) { }
        public DbSet<HostelModel> Hostel { get; set; }
        public DbSet<RoomModel> Room { get; set; }


    }
}
