using Microsoft.AspNetCore.Mvc;

namespace ProductProject.Controllers
{
    public class PartialViewController : Controller
    {
        //Partial View=Kısmi görünümler. Bir template veya bir yapıyı birden fazla sayfasa kullanabilmek için Partial View yapısı tasarlarız.
        public IActionResult Index()
        {
            return View();
        }
    }
}
