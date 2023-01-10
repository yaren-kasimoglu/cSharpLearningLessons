using Microsoft.AspNetCore.Mvc;
using ViewToController.Models;

namespace ViewToController.Controllers
{
    public class PersonalController : Controller
    {

        List<Personal> personalList = new List<Personal>()
        {
            new Personal(){Id=1, FirstName="Yaren", LastName="Kas", Gender=true,BirthDate=new DateTime(1998,02,01)},
            new Personal(){Id=2, FirstName="Toprak", LastName="Kası", Gender=false,BirthDate=new DateTime(2006,10,06)},
            new Personal(){Id=3, FirstName="Birsen", LastName="Kasım", Gender=true,BirthDate=new DateTime(1965,01,01)},
            new Personal(){Id=4, FirstName="Berivan", LastName="Kasımo", Gender=true,BirthDate=new DateTime(1992,05,18)}
        };
        public IActionResult Index()
        {
            return View(personalList);
        }

        public IActionResult GetDetailsById(int id)
        {
            Personal personal = personalList.FirstOrDefault(x => x.Id == id);
            return View(personal);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Personal gelenPersonal)
        {
            personalList.Add(gelenPersonal);

            return View("Index",personalList);
        }
    }
}
