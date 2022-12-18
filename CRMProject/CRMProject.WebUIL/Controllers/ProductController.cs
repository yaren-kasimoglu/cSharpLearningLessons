using CRMProject.BL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CRMProject.WebUIL.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            productService = _productService;
        }

        [HttpGet("product-list")]
        public IActionResult List()
        {
            return View();
        }
        [HttpGet("product-detail/{id?}")]
        public IActionResult Detail()
        {
            return View();
        }

    }
}
