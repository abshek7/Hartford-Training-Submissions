using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BlogContext _context;

        public BlogsController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/blogs
        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await _context.Blogs.ToListAsync();

            return Ok(new
            {
                success = true,
                message = "Blogs retrieved successfully",
                data = blogs
            });
        }

        // GET: api/blogs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"Blog with ID {id} not found"
                });
            }

            return Ok(new
            {
                success = true,
                data = blog
            });
        }

        // POST: api/blogs
        [HttpPost]
        public async Task<IActionResult> PostBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, new
            {
                success = true,
                message = "Blog created successfully",
                data = blog
            });
        }

        // PUT: api/blogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "ID mismatch"
                });
            }

            _context.Entry(blog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Blog not found"
                    });
                }
                throw;
            }

            return Ok(new
            {
                success = true,
                message = "Blog updated successfully"
            });
        }

        // DELETE: api/blogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Blog not found"
                });
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Blog deleted successfully"
            });
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}
