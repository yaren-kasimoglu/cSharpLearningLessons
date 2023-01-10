using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class Customer1Controller : Controller
    {
        [HttpGet("customer/detail/{id?}")]
        public IActionResult Detail(int? id)
        {
            return View();
        }
        [HttpGet("customer/list")]
        public IActionResult List()
        {
            return View();
        }
    }
}
