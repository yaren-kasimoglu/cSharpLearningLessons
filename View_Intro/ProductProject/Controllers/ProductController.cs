using Microsoft.AspNetCore.Mvc;
using ProductProject.Models;

namespace ProductProject.Controllers
{
    public class ProductController : Controller
    {
        

        public IActionResult Index()
        {
            List<ProductVM> productVMs = new List<ProductVM>()
            {
                new ProductVM() { ProductName = "Jbl Pembe",Price=999,ImageUrl="/images/pembe.jpeg" },
                new ProductVM() { ProductName = "Jbl Mavi",Price=999,ImageUrl="/images/lacivert.jpeg" },
                new ProductVM() { ProductName = "Siyah",Price=999,ImageUrl="/images/siyah.jpeg" }
            };
            return View(productVMs);
        }
    }
}
