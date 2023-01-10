using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TagHelperWithHttpsConf.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TagHelperWithHttpsConf.Controllers
{
    public class InputController : Controller
    {
        private List<SelectListItem> Departments = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "1",Text = "Yazılım Departmanı"},
                new SelectListItem() { Value = "2",Text = "Muhasebe Departmanı"},
                new SelectListItem() { Value = "3",Text = "Finans Departmanı"},
                new SelectListItem() { Value = "4",Text = "Depo Departmanı"},
            };
        public IActionResult Index()
        {
            ViewBag.Departments = Departments;
            return View();
        }

        [HttpPost]
        public IActionResult Index(PersonalVM personal)
        {
            ViewBag.Departments = Departments;
            return View(personal);
        }
    }
}
