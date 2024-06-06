using Microsoft.AspNetCore.Mvc;
using OmerProject.Models;
using OmerProject.Services;
using System.Diagnostics;

namespace OmerProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginCounterService _loginCounterService;
        
        public HomeController(ILogger<HomeController> logger, LoginCounterService loginCounterService)
        {
            _loginCounterService = loginCounterService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["VisitorCount"] = _loginCounterService.GetCount();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
