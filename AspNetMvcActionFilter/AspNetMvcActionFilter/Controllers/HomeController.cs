using AspNetMvcActionFilter.Filters.ActionFilter;
using AspNetMvcActionFilter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetMvcActionFilter.Controllers
{
    [TypeFilter(typeof(ExceptionFilterAttribute))]
    //[SampleActionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [SampleActionFilter]
        public IActionResult Index()
        {
            throw new Exception("Yazılımcı tarafından fırlatıldı");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}