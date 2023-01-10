using Microsoft.AspNetCore.Mvc;

namespace MVC_Intro2.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
