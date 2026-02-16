using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly BlogContext _context;

        public CommentsController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/comments
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _context.Comments.ToListAsync();

            return Ok(new
            {
                success = true,
                message = "Comments retrieved successfully",
                data = comments
            });
        }

        // GET: api/comments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"Comment with ID {id} not found"
                });
            }

            return Ok(new
            {
                success = true,
                data = comment
            });
        }

        // POST: api/comments
        [HttpPost]
        public async Task<IActionResult> PostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, new
            {
                success = true,
                message = "Comment created successfully",
                data = comment
            });
        }

        // PUT: api/comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "ID mismatch"
                });
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Comment not found"
                    });
                }
                throw;
            }

            return Ok(new
            {
                success = true,
                message = "Comment updated successfully"
            });
        }

        // DELETE: api/comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Comment not found"
                });
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Comment deleted successfully"
            });
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
