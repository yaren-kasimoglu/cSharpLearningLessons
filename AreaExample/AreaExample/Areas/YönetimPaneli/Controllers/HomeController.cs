using Microsoft.AspNetCore.Mvc;

namespace AreaExample.Areas.YönetimPaneli.Controllers
{
    [Area("yonetimpaneli")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
