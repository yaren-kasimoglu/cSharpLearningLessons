using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreRouting.Controllers
{
    public class BlogController : Controller
    {
        
        public IActionResult Index(string article)
        {
            return View();
        }
    }
}
