using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlProject.Entities.Entities;
using StockControlProject.Service.Abstract;

namespace StockControlProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericService<Category> _service;

        public CategoryController(IGenericService<Category> service)
        {
            _service = service;
        }

        // GET: api/Category/TumKategorileriGetir
        [HttpGet]
        public IActionResult TumKategorileriGetir()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/Category/AktifKategorileriGetir/5
        [HttpGet]
        public IActionResult AktifKategorileriGetir()
        {
            return Ok(_service.GetActive());
        }

        [HttpGet("{id}")]
        public IActionResult IdyeGoreKategoriGetir(int id)
        {
            return Ok(_service.GetById(id));
        }
        // POST: api/Category/KategoriEkle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult KategoriEkle(Category category)
        {
            _service.Add(category);

            return CreatedAtAction("IdyeGoreKategoriGetir", new { id = category.Id }, category);
        }

        // PUT: api/Category/KategorileriGuncelle/5
        [HttpPut("{id}")]
        public IActionResult KategorileriGuncelle(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            //_service.Entry(category).State = EntityState.Modified;

            try
            {
                _service.Update(category);
                return Ok(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }

            }

            return NoContent();
        }



        // DELETE: api/Category/KategoriSil/5
        [HttpDelete("{id}")]
        public IActionResult KategoriSil(int id)
        {
            var category = _service.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            try
            {
                _service.Remove(category);
                return Ok("Kategori Silindi!");
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }


        private bool CategoryExists(int id)
        {
            return _service.Any(e => e.Id == id);
        }


        [HttpGet("{id}")]
        public IActionResult KategoriAktiflestir(int id)
        {
            var category = _service.GetById(id);
            if (category == null)
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
