using BlogApp.Application.DTOs;
using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepo;

        public BlogsController(IBlogRepository blogRepo)
        {
            _blogRepo = blogRepo;
        }

        // GET: api/blogs
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BlogReadDto>>> GetBlogs()
        {
            var blogs = await _blogRepo.GetAllAsync();

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

        // GET: api/blogs/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BlogReadDto>> GetBlog(int id)
        {
            var blog = await _blogRepo.GetByIdAsync(id);

            if (blog == null)
                return NotFound();

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

        // POST
        [HttpPost]
        [Authorize(Roles = "Admin,Author")]
        public async Task<IActionResult> Create(BlogCreateDto dto)
        {
            var blog = new Blog
            {
                Title = dto.Title,
                Content = dto.Content
            };

            await _blogRepo.AddAsync(blog);

            return Ok(new { message = "Blog created successfully" });
        }

        // PUT
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Author")]
        public async Task<IActionResult> Update(int id, BlogUpdateDto dto)
        {
            var blog = await _blogRepo.GetByIdAsync(id);

            if (blog == null)
                return NotFound();

            blog.Title = dto.Title;
            blog.Content = dto.Content;

            await _blogRepo.UpdateAsync(blog);

            return Ok(new { message = "Blog updated successfully" });
        }

        // DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogRepo.GetByIdAsync(id);

            if (blog == null)
                return NotFound();

            await _blogRepo.DeleteAsync(blog);

            return Ok(new { message = "Blog deleted successfully" });
        }
    }
}