using _02_ViewModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace _02_ViewModel.Controllers
{
    public class FutbolcuController : Controller
    {
        public IActionResult Index()
        {
            List<Futbolcu> futbolcular = new List<Futbolcu>()
            {
                new Futbolcu()

            };
            return View();
        }
    }
}
