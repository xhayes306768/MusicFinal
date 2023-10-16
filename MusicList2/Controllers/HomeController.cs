using Microsoft.AspNetCore.Mvc;
using MusicList2.Models;
using System.Diagnostics;

namespace MusicList2.Controllers
{
    public class HomeController : Controller
    {
        private MusicContext context { get; set; }
        public HomeController(MusicContext ctx) => context = ctx;
        public IActionResult Index()
        {
            var music = context.Music.OrderBy(m => m.MusicId).ToList();
            return View(music);




        }
    }
}