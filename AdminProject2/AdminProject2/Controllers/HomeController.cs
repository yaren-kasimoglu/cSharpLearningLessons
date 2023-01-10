using Microsoft.AspNetCore.Mvc;

namespace AdminProject2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
