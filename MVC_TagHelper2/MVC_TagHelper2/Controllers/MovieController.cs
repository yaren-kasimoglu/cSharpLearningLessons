using Microsoft.AspNetCore.Mvc;
using MVC_TagHelper2.Models;

namespace MVC_TagHelper2.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            var movie = new MovieVM();
            movie.ID = 1;
            movie.Title = "X";
            movie.RleaseDate = DateTime.Now;
            movie.Price = 12;
            return View(movie);
        }
    }
}
