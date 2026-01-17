using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StartAppMVC.Models;
using System.Threading.Tasks;

namespace StartAppMVC.Controllers
{
    public class RequestsController : Controller
    {
        // GET: RequestsController
        private readonly IBlogRepository _repo;

        public RequestsController(IBlogRepository repo, IRequestLogRepository logrepo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var request = await _repo.ge
            return View(authors);
        }
    }
}
