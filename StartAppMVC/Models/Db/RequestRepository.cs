using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace StartAppMVC.Models.Db
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async  Task AddRequest(Request request)
        {
           _context.Requests.AddAsync(request);
           _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequest()
        {
            return await _context.Requests
                .OrderByDescending(r => r.Date)
                .ToArrayAsync();
        }
    }
}
