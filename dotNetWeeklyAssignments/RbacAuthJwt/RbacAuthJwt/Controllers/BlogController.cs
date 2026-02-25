using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RbacAuthJwt.Data;
using RbacAuthJwt.DTOs;
using RbacAuthJwt.Models; 
namespace RbacAuthJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogController : ControllerBase
    {
        private readonly AuthDbContext _db;
        public BlogController(AuthDbContext db)
        {
            _db = db;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll() {
            return Ok(await _db.Blogs.ToListAsync());
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Author")]
        public async Task<IActionResult> Create(BlogCreateDto dto)
        {
            var blog = new Blog
            {
                Title = dto.Title,
                Content = dto.Content,
                Author = dto.Author,

            };
            _db.Blogs.Add(blog);
            await _db.SaveChangesAsync();
            return Ok(blog);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Author")]

        public async Task<IActionResult> Update(int id,BlogUpdateDto dto)
        {
            var blog = await _db.Blogs.FindAsync(id);
            if(blog == null) return NotFound();
            blog.Title = dto.Title;
            blog.Content = dto.Content;
            _db.Blogs.Add(blog);
            await _db.SaveChangesAsync();
            return Ok(blog);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _db.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            _db.Blogs.Remove(blog);

            await _db.SaveChangesAsync();
            return NoContent();


        }
    }
}
