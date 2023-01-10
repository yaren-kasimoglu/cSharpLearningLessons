using Microsoft.AspNetCore.Mvc;
using TagHelperWithHttpsConf.Models;

namespace TagHelperWithHttpsConf.Controllers
{
    public class AnchorController : Controller
    {
        List<ProductVM> productList = new List<ProductVM>()
        {
            new ProductVM(){Id=1, ProductName="Çikolata"},
            new ProductVM(){Id=2, ProductName="Çikolata2"},
            new ProductVM(){Id=3, ProductName="Çikolata3"},
            new ProductVM(){Id=4, ProductName="Çikolata4"},
            new ProductVM(){Id=5, ProductName="Çikolata5"},
            new ProductVM(){Id=6, ProductName="Çikolata6"},
        };
        public IActionResult Index()
        {
            return View();
        }
        [Route("product-list",Name ="urun-listesi")] 
        public IActionResult ProductList()
        {
            return View(productList);
        }
        [Route("product/{id:int}")] //routing
        public IActionResult Product(int id)
        {
            var product = productList.FirstOrDefault(x => x.Id ==id);
            return View(product);
        }
    
}
}
