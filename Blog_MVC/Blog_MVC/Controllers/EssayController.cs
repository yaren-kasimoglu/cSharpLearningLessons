using Blog_MVC.DTO.Abstract;
using Blog_MVC.DTO.Concrete;
using Blog_MVC.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog_MVC.Controllers
{
    public class EssayController : Controller
    {
        private readonly RoleManager<UserRole> _roleManager;
        private readonly UserManager<UserAccount> _userManager;
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEssay()
        {
            return View();
        }

  
    }
}
