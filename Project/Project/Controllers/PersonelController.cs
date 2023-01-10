using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class PersonelController : Controller
    {
        [HttpGet("personal/detail/{id?}")]
        public IActionResult Detail(int? id)
        {
            return View();
        }
        [HttpGet("personal/list")]
        public IActionResult List()
        {
            return View();
        }
    }
}
