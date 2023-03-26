using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlProject.Entities.Entities;
using StockControlProject.Service.Abstract;

namespace StockControlProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericService<Product> _service;

        public ProductController(IGenericService<Product> service)
        {
            _service = service;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult TumUrunleriGetir()
        {
            return Ok(_service.GetAll(t0=>t0.Category,t1=>t1.Supplier ));
        }

        // GET: api/product
        [HttpGet()]
        public IActionResult AktifUrunleriGetir()
        {
            return Ok(_service.GetActive(t0 => t0.Category, t1 => t1.Supplier));
        }

        // GET: api/product/
        [HttpGet("{id}")]
        public IActionResult IdyeGoreUrunleriGetir(int id)
        {
            return Ok(_service.GetById(id));
        }
        // POST api/product
        [HttpPost]
        public IActionResult UrunEkle(Product product)
        {
            _service.Add(product);

            return CreatedAtAction("IdyeGoreUrunleriGetir", new { id = product.Id }, product);
        }


        // PUT: api/product
        [HttpPut("{id}")]
        public IActionResult UrunGuncelle(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.Update(product);
                return Ok(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // DELETE: api/product
        [HttpDelete("{id}")]
        public IActionResult UrunSil(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            try
            {
                _service.Remove(product);
                return Ok("Urun silindi");
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        private bool ProductExists(int id)
        {
            return _service.Any(e => e.Id == id);
        }
        [HttpGet("{id}")]
        public IActionResult UrunAktiflestir(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            try
            {
                _service.Activate(id);
                return Ok(_service.GetById(id));
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}
