using Microsoft.AspNetCore.Mvc;

namespace TagHelperWithoutHttpsConfig.Controllers
{
    public class AnchorController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
