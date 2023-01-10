using Microsoft.AspNetCore.Mvc;
using Mvc_RazorViewEngine.Models;

namespace Mvc_RazorViewEngine.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var productCategoryVm = new ProductCategoryVM();
            productCategoryVm.Categories = new CategoryVM();
            productCategoryVm.Categories.Id = 1;
            productCategoryVm.Categories.CategoryName = "Atıştırmalık";
            productCategoryVm.Categories.Description = "Açıklama Bölümü";

            productCategoryVm.Products = new List<ProductVM>();

            productCategoryVm.Products.Add(new ProductVM() { Id = 1, Name = "Dondurma", Price = 12, ProductDescription = "Bu ürün bir dondurmadır" });
            productCategoryVm.Products.Add(new ProductVM() { Id = 2, Name = "Çikolata", Price = 15, ProductDescription = "Bu ürün bir çikolatadır" });

            return View(productCategoryVm);
        }
    }
}
