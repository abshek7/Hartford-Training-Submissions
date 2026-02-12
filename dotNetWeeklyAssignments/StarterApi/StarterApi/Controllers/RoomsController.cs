using Microsoft.AspNetCore.Mvc;
using StarterApi.Models;

namespace StarterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        // In-memory data
        private static List<Room> rooms = new List<Room>
        {
            new Room { RoomId = 1, Type = "Single", Capacity = 2, IsAvailable = true },
            new Room { RoomId = 2, Type = "Dorm", Capacity = 1, IsAvailable = true },
            new Room { RoomId = 3, Type = "Double", Capacity = 3, IsAvailable = true },
        };

        // GET: api/Rooms
        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRooms()
        {
            return Ok(rooms);
        }



        // GET: api/Rooms/{id}
        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var room = rooms.FirstOrDefault(r => r.RoomId == id);

            if (room == null)
                return NotFound();

            return Ok(room);
        }

        // POST: api/Rooms
        [HttpPost]
        public IActionResult CreateRoom(Room room)
        {
            // Generate new ID
            room.RoomId = rooms.Count > 0
                ? rooms.Max(r => r.RoomId) + 1
                : 1;

            rooms.Add(room);

            return CreatedAtAction(nameof(GetRoom),
           new { id = room.RoomId },room);
        }

        //PUT api/Rooms/{id}
        [HttpPut]
        public IActionResult UpdateRoom(int id,Room updatedRoom)
        {
            var room=rooms.FirstOrDefault(r => r.RoomId == id);
            if(room == null)
                return NotFound("room is not found");
            room.Capacity = updatedRoom.Capacity;
            room.IsAvailable = updatedRoom.IsAvailable;
            return NoContent();

        }

        // DELETE /api/Rooms/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var room = rooms.FirstOrDefault(r => r.RoomId == id);
            if (room == null)
                return NotFound();
           rooms.Remove(room);
            return NoContent();


        }
    }
}
