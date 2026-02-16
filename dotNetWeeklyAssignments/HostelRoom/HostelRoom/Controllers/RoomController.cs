using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HostelRoom.Models;

namespace HostelRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly HostelContext _context;

        public RoomController(HostelContext context)
        {
            _context = context;
        }

        // GET: api/Room
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<RoomModel>>> GetRoom()
        //{
        //    return await _context.Room.ToListAsync();
        
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomModel>>> GetRoom()
        {
            return await _context.Room
                .Include(r => r.Hostel)
                .ToListAsync();
        }


        // GET: api/Room/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<RoomModel>> GetRoomModel(long id)
        //{
        //    var roomModel = await _context.Room.FindAsync(id);

        //    if (roomModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return roomModel;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> GetRoomModel(long id)
        {
            var roomModel = await _context.Room
                .Include(r => r.Hostel)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (roomModel == null)
            {
                return NotFound();
            }

            return roomModel;
        }


        // PUT: api/Room/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomModel(long id, RoomModel roomModel)
        {
            if (id != roomModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Room
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<RoomModel>> PostRoomModel(RoomModel roomModel)
        //{
        //    _context.Room.Add(roomModel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRoomModel", new { id = roomModel.Id }, roomModel);
        //}


        [HttpPost]
        public async Task<ActionResult<RoomModel>> PostRoomModel(RoomModel roomModel)
        {
            _context.Room.Add(roomModel);
            await _context.SaveChangesAsync();

            var result = await _context.Room
                .Include(r => r.Hostel)
                .FirstOrDefaultAsync(r => r.Id == roomModel.Id);

            return CreatedAtAction("GetRoomModel", new { id = roomModel.Id }, result);
        }


        // DELETE: api/Room/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomModel(long id)
        {
            var roomModel = await _context.Room.FindAsync(id);
            if (roomModel == null)
            {
                return NotFound();
            }

            _context.Room.Remove(roomModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomModelExists(long id)
        {
            return _context.Room.Any(e => e.Id == id);
        }
    }
}
