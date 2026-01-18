using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StartAppMVC.Models;
using System.Threading.Tasks;

namespace StartAppMVC.Controllers
{
    public class LogsController : Controller
    {
        // GET: RequestsController
        private readonly IRequestRepository _repo;

        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var request = await _repo.GetRequest();
            return View(request);
        }
    }
}
