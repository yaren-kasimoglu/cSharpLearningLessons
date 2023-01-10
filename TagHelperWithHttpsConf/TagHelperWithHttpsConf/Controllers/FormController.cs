using Microsoft.AspNetCore.Mvc;
using TagHelperWithHttpsConf.Models;

namespace TagHelperWithHttpsConf.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("form-save", Name ="form-save")]
        [HttpPost] //Bu method http post isteklerine cevap verir. OnModel Binding??
        public IActionResult FormSave(ProductVM product)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
