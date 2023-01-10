using BlogProject.Core.Entity.Service;
using BlogProject.Entities.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProject.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICoreService<User> _userService;

        public AccountController(ICoreService<User> userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            //kullanıcının db de olup olmadığını kontrol ediyoruz. 
            if (_userService.Any(x => x.EmailAddress == user.EmailAddress && x.Password == user.Password))
            {
                //Eğer kullanıcı db de var ise kullanıcıyı yakalıyoruz
                User loggedUser = _userService.GetByDefault(x => x.EmailAddress == user.EmailAddress && x.Password == user.Password);

                //kullanıcnın saklanılacak bilgilerini Claimler olarak tutabilriz.

                var claims = new List<Claim>()
                {
                new Claim("ID" , loggedUser.ID.ToString()),
                new Claim(ClaimTypes.Name , loggedUser.FirstName),
                new Claim(ClaimTypes.Surname , loggedUser.LastName),
                new Claim(ClaimTypes.Email , loggedUser.EmailAddress),
                new Claim("ImageURL" , loggedUser.ImageURL),
                };

                var userIdentity=new ClaimsIdentity(claims,"login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal); //kullanıcı girişi yaptırılır.

                return RedirectToAction("Index","Home", new {area= "Administrator" });

            }

            //eğer giriş yapamazsa kullanıcı bilgileriyle forma dönsün

            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });//çıkış yapıldıktan sonra blog ana sayfasına yönlendirmek için
        }
    }
}
