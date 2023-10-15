using Microsoft.AspNetCore.Mvc;
using MusicList2.Models;
using System.Diagnostics;

namespace MusicList2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        
    }
}