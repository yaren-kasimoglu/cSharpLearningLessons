using Microsoft.AspNetCore.Mvc;

namespace TagHelperWithHttpsConf.Controllers
{
    public class CacheController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
