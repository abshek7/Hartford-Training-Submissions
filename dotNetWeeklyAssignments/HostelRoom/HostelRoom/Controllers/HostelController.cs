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
    public class HostelController : ControllerBase
    {
        private readonly HostelContext _context;

        public HostelController(HostelContext context)
        {
            _context = context;
        }

        // GET: api/Hostel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HostelModel>>> GetHostel()
        {
            return await _context.Hostel.ToListAsync();
        }

        // GET: api/Hostel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HostelModel>> GetHostelModel(long id)
        {
            var hostelModel = await _context.Hostel.FindAsync(id);

            if (hostelModel == null)
            {
                return NotFound();
            }

            return hostelModel;
        }

        // PUT: api/Hostel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHostelModel(long id, HostelModel hostelModel)
        {
            if (id != hostelModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(hostelModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostelModelExists(id))
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

        // POST: api/Hostel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HostelModel>> PostHostelModel(HostelModel hostelModel)
        {
            _context.Hostel.Add(hostelModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHostelModel", new { id = hostelModel.Id }, hostelModel);
        }

        // DELETE: api/Hostel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHostelModel(long id)
        {
            var hostelModel = await _context.Hostel.FindAsync(id);
            if (hostelModel == null)
            {
                return NotFound();
            }

            _context.Hostel.Remove(hostelModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HostelModelExists(long id)
        {
            return _context.Hostel.Any(e => e.Id == id);
        }
    }
}
