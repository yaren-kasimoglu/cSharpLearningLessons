using AutoMapper;
using HS7_BP.Application.Models.DTOs.AppUserDTOs;
using HS7_BP.Application.Services.AppUserServices;
using HS7_BP.UI.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HS7_BP.UI.Controllers
{
    [Authorize]
    //Bu attribute ile sisteme login olunma zorunluluğu getiriyoruz. Sistem sağlıklı bir şeklde çalıştığında bütün controller'ları bu attribute ile işaretleyeceğiz.
     //Örneğin bir e ticaret sitesinde kullanıcılara login olmadan ürünleri görebilmektedir. O halde ürünleri gösteren controller bu attribu ile işaretlenmemiştir.
     //Sepet ile ilgili işlem yapıldığında ise günlük hayattan hatırlayacağınız gibi uygulamalar bizi login olmaya zorlamaktadır. Bu bağlamda sepet controller'ı "Authorize" attribute ile işaretlenmiştir.
     //Bizim uygulamamızda admin area bulunan bütün controller'lar bu attribu ile işaretlenecektir. Çünkü kimlik doğrulaması yaparak sisteme girmiş kişiler ilgii işlemeleri yapabilme yeteneğine sahip olacaktır.

    public class AccountController : Controller
    {
        IAppUserService _appUserService; //field
        IMapper _mapper;
        public AccountController(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        //constructor
        //public AccountController(IAppUserService appUserService)=>  _appUserService = appUserService; 


        [AllowAnonymous]//Bu attribute sayesinde ilgili action methodun Authorize kapsamından çıkmasını istiyoruz. Neden? Çünkü kullanıcı herhangi bir kimlik doğrulamasından yani authentication işleminden geçmeden Register sayfasını görebilmeili ve sisteme register olabilmelidir.
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)//Kullanıcı giriş yapmışsa anasayfaya yönlendirilsin.
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<RegisterDTO>(vm);
                var result = await _appUserService.Register(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                    TempData["error"] = "Kayıt Oluşturulurken Bir Hata Meydana Geldi";
                }
            }
            return View(vm);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (ModelState.IsValid)
            {
                var _loginDto = _mapper.Map<LoginDTO>(vm);
                var result = await _appUserService.Login(_loginDto);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["error"] = "Giriş İşlemi Başarısız!!!";
            return View(vm);
        }


        public async Task<IActionResult> LogOut()
        {
            await _appUserService.LogOut();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return RedirectToAction("Login");
        }
    }
}
