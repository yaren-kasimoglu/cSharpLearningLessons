using Microsoft.AspNetCore.Mvc;

namespace Area_Example.Areas.Order.Controllers
{
    [Area("Order")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
