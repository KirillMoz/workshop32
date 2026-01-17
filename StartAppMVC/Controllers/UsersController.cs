using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StartAppMVC.Models;
using StartAppMVC.Models.Db;

namespace StartAppMVC.Controllers
{
    public class UsersController: Controller
    {
        private readonly IBlogRepository _repo;
        private readonly IRequestLogRepository _log;

        public UsersController(IBlogRepository repo, IRequestLogRepository log)
        {
            _repo = repo;
            _log = log;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            // Добавление пользователя
            await _repo.AddUser(user);
            return View(user);
        }
    }
}
