using Microsoft.AspNetCore.Mvc;
using MVC_TagHelper2.Models;

namespace MVC_TagHelper2.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            var personel = new PersonelVM();
            personel.Id = 1;
            personel.PersonelName = "YarenKas";
            personel.Age = 24;
            personel.Address = "İzmit/Kocaeli";
            return View(personel);
        }
    }
}
