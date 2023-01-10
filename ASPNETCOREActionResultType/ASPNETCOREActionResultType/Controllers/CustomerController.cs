using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREActionResultType.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult Deneme1()
        {
            return PartialView("PartialView1");
        }
    }
}
