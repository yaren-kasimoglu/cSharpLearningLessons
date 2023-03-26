using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlProject.Entities.Entities;
using StockControlProject.Service.Abstract;

namespace StockControlProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IGenericService<Supplier> _service;

        public SupplierController(IGenericService<Supplier> service)
        {
            _service = service;
        }

        // GET: api/Supplier
        [HttpGet]
        public IActionResult TumTedarikcileriGetir()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/Supplier
        [HttpGet()]
        public IActionResult AktifTedarikcileriGetir()
        {
            return Ok(_service.GetActive());
        }

        // GET: api/Supplier/
        [HttpGet("{id}")]
        public IActionResult IdyeGoreTedarirkcileriGetir(int id)
        {
            return Ok(_service.GetById(id));
        }
        // POST api/Supplier
        [HttpPost]
        public IActionResult TedarikciEkle(Supplier supplier)
        {
            _service.Add(supplier);

            return CreatedAtAction("IdyeGoreTedarirkcileriGetir", new { id = supplier.Id }, supplier);
        }


        // PUT: api/Supplier
        [HttpPut("{id}")]
        public IActionResult TedarikciGuncelle(int id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.Update(supplier);
                return Ok(supplier);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // DELETE: api/Supplier
        [HttpDelete("{id}")]
        public IActionResult TedarikciSil(int id)
        {
            var supplier = _service.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            try
            {
                _service.Remove(supplier);
                return Ok("Tedarikçi silindi");
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        private bool SupplierExists(int id)
        {
            return _service.Any(e => e.Id == id);
        }
        [HttpGet("{id}")]
        public IActionResult TedarikciAktiflestir(int id)
        {
            var supplier = _service.GetById(id);
            if (supplier == null)
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
