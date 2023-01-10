using AspNetCoreRouting.Extension;
using AspNetCoreRouting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreRouting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Multiple Route verebiliyoruz  acitonlara
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        [Route("Home/Index/{id?}")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("customer/[action]/{id?}")]
        public IActionResult Index2(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
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