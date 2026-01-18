using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StartAppMVC.Models.Db
{
    public class BlogRepository : IBlogRepository, IRequestRepository
    {
        private readonly BlogContext _context;

        public BlogRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task AddUser(User user)
        {
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            return await _context.Requests
                .OrderByDescending(r => r.Date)
                .ToArrayAsync();
        }

        public async Task AddRequest(Request request)
        {
            request.Id = Guid.NewGuid();

            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequest()
        {
            return await _context.Requests
                .OrderByDescending(r => r.Date)
                .ToArrayAsync();
        }
    }
}