using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlProject.Entities.Entities;
using StockControlProject.Service.Abstract;

namespace StockControlProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericService<User> _service;

        public UserController(IGenericService<User> service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult TumKullanicilariGetir()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/
        [HttpGet()]
        public IActionResult AktifKullancılarıGetir()
        {
            return Ok(_service.GetActive());
        }

        // GET: api/
        [HttpGet("{id}")]
        public IActionResult IdyeGoreKullanicilariGetir(int id)
        {
            return Ok(_service.GetById(id));
        }
        // POST api/
        [HttpPost]
        public IActionResult KullaniciEkle(User user)
        {
            _service.Add(user);

            return CreatedAtAction("IdyeGoreKullancılarıGetir", new { id = user.Id }, user);
        }


        // PUT: api/
        [HttpPut("{id}")]
        public IActionResult KullaniciGuncelle(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.Update(user);
                return Ok(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // DELETE: api/
        [HttpDelete("{id}")]
        public IActionResult KullaniciSil(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            try
            {
                _service.Remove(product);
                return Ok("Kullancı silindi");
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        private bool UserExists(int id)
        {
            return _service.Any(e => e.Id == id);
        }
        [HttpGet("{id}")]
        public IActionResult KullaniciAktiflestir(int id)
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
        [HttpGet]
        public IActionResult Login(string email, string password)
        {
            if (_service.Any(x => x.Email == email && x.Password == password))
            {
                User logged = _service.GetByDefault(x => x.Email == email && x.Password == password);
                return Ok(logged);
            }
            return NotFound();
        }
    }
}