using Microsoft.AspNetCore.Mvc;

namespace CRMProject.WebUI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
