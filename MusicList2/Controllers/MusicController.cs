using Microsoft.AspNetCore.Mvc;

namespace MusicList2.Controllers
{
    public class MusicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
