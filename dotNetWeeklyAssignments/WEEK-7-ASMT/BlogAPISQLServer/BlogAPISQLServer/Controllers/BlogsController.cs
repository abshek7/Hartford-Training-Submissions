using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPISQLServer.Models;
using BlogAPISQLServer.DTOs;

namespace BlogAPISQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BlogDbContext _context;

        public BlogsController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: api/Blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogReadDto>>> GetBlogs()
        {
            var blogs = await _context.Blogs
                .Include(b => b.Comments)
                .ToListAsync();

            var result = blogs.Select(b => new BlogReadDto
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                Comments = b.Comments.Select(c => new CommentReadDto
                {
                    Id = c.Id,
                    Message = c.Message,
                    Author = c.Author,
                    BlogId = c.BlogId
                }).ToList()
            });

            return Ok(result);
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogReadDto>> GetBlog(int id)
        {
            var blog = await _context.Blogs
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null)
                return NotFound(new { message = $"Blog with Id {id} not found" });

            var result = new BlogReadDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                Comments = blog.Comments.Select(c => new CommentReadDto
                {
                    Id = c.Id,
                    Message = c.Message,
                    Author = c.Author,
                    BlogId = c.BlogId
                }).ToList()
            };

            return Ok(result);
        }

        // POST: api/Blogs
        [HttpPost]
        public async Task<ActionResult<BlogReadDto>> PostBlog(BlogCreateDto dto)
        {
            var blog = new Blog
            {
                Title = dto.Title,
                Content = dto.Content
            };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            var result = new BlogReadDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                Comments = new List<CommentReadDto>()
            };

            return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, result);
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, BlogUpdateDto dto)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
                return NotFound(new { message = $"Blog with Id {id} not found" });

            blog.Title = dto.Title;
            blog.Content = dto.Content;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Blog updated successfully" });
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
                return NotFound(new { message = $"Blog with Id {id} not found" });

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Blog deleted successfully" });
        }
    }
}
