using _01_ModelNedir.Models;
using _01_ModelNedir.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace _01_ModelNedir.Controllers
{
    public class PersonelController : Controller
    {
        static List<Department> departments = new List<Department>()
        {
            new Department{Id=1, DepartmentName="Yazılım"},
            new Department{Id=2, DepartmentName="İnsan Kaynakları"},
            new Department{Id=3, DepartmentName="Teknik Destek"},
            new Department{Id=4, DepartmentName="Muhasebe"}

        };
        List<Personel> personels = new List<Personel>()
        {
            new Personel{Id=1,Name="Yaren Kas", BirthDate=new DateTime(1997,12,15),WorkingType=WorkingType.FullTime,Department=departments.FirstOrDefault(x=>x.Id==2)},
            new Personel{Id=2,Name="Ayşe Test", BirthDate=new DateTime(1998,05,20),WorkingType=WorkingType.PartTime,Department=departments.FirstOrDefault(x=>x.Id==3)},
            new Personel{Id=3,Name="Fatma Deneme", BirthDate=new DateTime(1992,02,06),WorkingType=WorkingType.ProjectBase,Department=departments.FirstOrDefault(x=>x.Id==4)},
            new Personel{Id=4,Name="Hayriye TestDen", BirthDate=new DateTime(1993,03,03),WorkingType=WorkingType.Freelance, Department=departments.FirstOrDefault(x=>x.Id==1)}
        };

        public IActionResult Index()
        {
            return View(personels);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
