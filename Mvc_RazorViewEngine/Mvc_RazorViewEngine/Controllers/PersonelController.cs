using Microsoft.AspNetCore.Mvc;
using Mvc_RazorViewEngine.Models;

namespace Mvc_RazorViewEngine.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            //controller kısmından view kısmına veri gönderme işlemi

            ViewBag.Name = "Yaren Kasımoğlu ViewBag"; //dynamic tipindedir.
            ViewData["NameSurname"] = "Yaren Kasımoğlu ViewData"; //keyValue şeklinde kullanılır
            
            //sunucu taraflı yönlendirme işlemi yapılacak ise data temp data içerisinde alınmalısır. Diğer sayfadan sadece tempdata okunabilir
            TempData["NameSurname"] = "Yaren Kasımoğlu TempData"; //dictionary- keyvalue şeklinde çalışıyor
                                                                  //  return RedirectToAction("Index3","Personel"); //sunucu taraflı yönlendirme işlemi
            return View();
        }
        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult Index4()
        {
            var personalVm = new PersonelVM();
            personalVm.Id = 1;
            personalVm.Name = "Yaren";
            personalVm.Surname = "Kasımoğlu";

            return View(personalVm);
        }

        public IActionResult Index5()
        {
            var personelSalesvm = new PersonelSalesVM();
            personelSalesvm.Personel=new PersonelVM();

            personelSalesvm.Personel.Id = 1;
            personelSalesvm.Personel.Name = "Yaren";
            personelSalesvm.Personel.Surname = "Kasımoğlu";

            personelSalesvm.Sales = new List<SalesVM>();

            personelSalesvm.Sales.Add(new SalesVM() { ID = 1, Price = 10, ProductName = "Çikolata" });
            personelSalesvm.Sales.Add(new SalesVM() { ID = 2, Price = 20, ProductName = "Kek" });
            personelSalesvm.Sales.Add(new SalesVM() { ID = 3, Price = 30, ProductName = "Jel,ibon" });



            return View(personelSalesvm);
        }
    }
}
