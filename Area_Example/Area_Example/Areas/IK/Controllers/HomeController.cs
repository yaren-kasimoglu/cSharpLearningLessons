using Microsoft.AspNetCore.Mvc;

namespace Area_Example.Areas.IK.Controllers
{
    [Area("IK")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
