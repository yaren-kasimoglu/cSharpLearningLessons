using Microsoft.AspNetCore.Mvc;

namespace View_Intro.Controllers
{
    public class PartialViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
