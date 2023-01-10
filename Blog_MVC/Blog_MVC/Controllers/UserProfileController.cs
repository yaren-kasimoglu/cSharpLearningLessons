using Microsoft.AspNetCore.Mvc;

namespace Blog_MVC.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
