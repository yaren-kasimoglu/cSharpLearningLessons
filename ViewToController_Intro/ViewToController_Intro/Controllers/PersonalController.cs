using Microsoft.AspNetCore.Mvc;

namespace ViewToController_Intro.Controllers
{
    public class PersonalController : Controller
    {
        //Model Bind: Client tarafından alınan datanın ilkel veri tipleri(string int double decimal) veya complex tiplere(nezneler ile oluşturduğumuz tiplere) dönüştürme işlemidir.

        //[FromQuery]
        //[FromRoute]
        //[FromForm]
        //[FromBody]
        //[FromHeader]

        //[HttpGet("personal/{id})")]
        //public IActionResult Index(int id)
        //{
        //    return View();
        ////}
        //[HttpGet("personal/{id}/{Name}")]
        //public IActionResult Index(int id, string Name)
        //{
        //    return View();
        //}

        //[HttpGet("personal/{id})")]
        //public IActionResult Index(int id, bool isActive)
        //{
        //    return View();
        //}

        [HttpGet("personal/{id}/{Name}")]
        public IActionResult Index(int id, [FromRoute(Name = "Name")] string isim)
        {
            return View();
        }

        [HttpGet("personal/{id}")]
        public IActionResult Index(int id, bool isActive, [FromQuery(Name ="source")]string q)
        {
            return View();
        }
        [HttpPost ("personal")]
        public IActionResult Index([FromForm(Name="NameS")]string NameSurname)
        {
            return View();
        }


    }
}
