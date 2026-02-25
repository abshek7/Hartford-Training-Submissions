using BlogApp.Application.DTOs;
using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IBlogRepository _blogRepo;

        public CommentsController(
            ICommentRepository commentRepo,
            IBlogRepository blogRepo)
        {
            _commentRepo = commentRepo;
            _blogRepo = blogRepo;
        }

        // GET ALL COMMENTS
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CommentReadDto>>> GetComments()
        {
            var comments = await _commentRepo.GetAllAsync();

            var result = comments.Select(c => new CommentReadDto
            {
                Id = c.Id,
                Message = c.Message,
                Author = c.Author,
                BlogId = c.BlogId
            });

            return Ok(result);
        }

        // GET COMMENT BY ID
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CommentReadDto>> GetComment(int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            var result = new CommentReadDto
            {
                Id = comment.Id,
                Message = comment.Message,
                Author = comment.Author,
                BlogId = comment.BlogId
            };

            return Ok(result);
        }
 
        [HttpPost]
        [Authorize]   // Admin, Author, Reader all allowed
        public async Task<IActionResult> Create(CommentCreateDto dto)
        {
            var blog = await _blogRepo.GetByIdAsync(dto.BlogId);

            if (blog == null)
                return BadRequest("Invalid BlogId");
            var userName = User.Identity?.Name ?? "Unknown";

            var comment = new Comment
            {
                Message = dto.Message,
                Author = userName,
                BlogId = dto.BlogId
            };

            await _commentRepo.AddAsync(comment);

            return Ok(new { message = "Comment added successfully" });
        }

        // UPDATE COMMENT
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Author")]
        public async Task<IActionResult> Update(int id, CommentUpdateDto dto)
        {
            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            comment.Message = dto.Message;

            await _commentRepo.UpdateAsync(comment);

            return Ok(new { message = "Comment updated successfully" });
        }

        // DELETE COMMENT (ADMIN ONLY)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            await _commentRepo.DeleteAsync(comment);

            return Ok(new { message = "Comment deleted successfully" });
        }
    }
}