using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BlogApp.Domain.Entities;
using BlogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BlogApp.Application.Interfaces;

namespace BlogApp.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllAsync()
            => await _context.Blogs.Include(x => x.Comments).ToListAsync();

        public async Task<Blog?> GetByIdAsync(int id)
            => await _context.Blogs.Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Blog blog)
            => await _context.SaveChangesAsync();

        public async Task DeleteAsync(Blog blog)
        {
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }
    }
}