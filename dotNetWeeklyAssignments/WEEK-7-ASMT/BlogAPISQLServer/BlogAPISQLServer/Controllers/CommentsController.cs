using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPISQLServer.Models;
using BlogAPISQLServer.DTOs;

namespace BlogAPISQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly BlogDbContext _context;

        public CommentsController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentReadDto>>> GetComments()
        {
            var comments = await _context.Comments.ToListAsync();

            var result = comments.Select(c => new CommentReadDto
            {
                Id = c.Id,
                Message = c.Message,
                Author = c.Author,
                BlogId = c.BlogId
            });

            return Ok(result);
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentReadDto>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
                return NotFound(new { message = $"Comment with Id {id} not found" });

            var result = new CommentReadDto
            {
                Id = comment.Id,
                Message = comment.Message,
                Author = comment.Author,
                BlogId = comment.BlogId
            };

            return Ok(result);
        }

        // POST: api/Comments
        [HttpPost]
        public async Task<ActionResult<CommentReadDto>> PostComment(CommentCreateDto dto)
        {
            var blogExists = await _context.Blogs.AnyAsync(b => b.Id == dto.BlogId);

            if (!blogExists)
                return BadRequest(new { message = "Invalid BlogId. Blog does not exist." });

            var comment = new Comment
            {
                Message = dto.Message,
                Author = dto.Author,
                BlogId = dto.BlogId
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            var result = new CommentReadDto
            {
                Id = comment.Id,
                Message = comment.Message,
                Author = comment.Author,
                BlogId = comment.BlogId
            };

            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, result);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, CommentUpdateDto dto)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
                return NotFound(new { message = $"Comment with Id {id} not found" });

            comment.Message = dto.Message;
            comment.Author = dto.Author;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Comment updated successfully" });
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
                return NotFound(new { message = $"Comment with Id {id} not found" });

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Comment deleted successfully" });
        }
    }
}
