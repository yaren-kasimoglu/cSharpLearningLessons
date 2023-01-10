using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreRouting.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
