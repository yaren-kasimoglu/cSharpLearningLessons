using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockControlProject.Entities.Entities;
using StockControlProject.Entities.Enums;
using StockControlProject.Service.Abstract;

namespace StockControlProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IGenericService<User> _userService;
        private readonly IGenericService<Product> _productService;
        private readonly IGenericService<OrderDetails> _odService;
        private readonly IGenericService<Order> _orderService;

        public OrderController(IGenericService<User> userService, IGenericService<Product> productService, IGenericService<OrderDetails> odService, IGenericService<Order> orderService)
        {
            _userService = userService;
            _productService = productService;
            _odService = odService;
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult TumSiparisleriGetir()
        {
            return Ok(_orderService.GetAll(t0 => t0.OrderDetails, y1 => y1.User));
        }

        // GET: api/Order
        [HttpGet()]
        public IActionResult AktifSiparisleriGetir()
        {
            return Ok(_orderService.GetActive());
        }

        // GET: api/Order/
        [HttpGet("{id}")]
        public IActionResult IdyeGoreSiparisleriGetir(int id)
        {
            return Ok(_orderService.GetById(id,t0=>t0.OrderDetails, y1=>y1.User));
        }
        [HttpGet]
        public IActionResult BekleyenSiparisleriGetir()
        {
            return Ok(_orderService.GetDefault(x => x.Status == Status.Pending).ToList());
        }
        [HttpGet]
        public IActionResult OnaylananSiparisleriGetir()
        {
            return Ok(_orderService.GetDefault(x => x.Status == Status.Confirmed).ToList());
        }
        [HttpGet]
        public IActionResult ReddedilenSiparisleriGetir()
        {
            return Ok(_orderService.GetDefault(x => x.Status == Status.Cancelled).ToList());
        }
        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult SiparisSil(int id)
        {
            var order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            try
            {
                _orderService.Remove(order);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Ürün Silindi!");
        }
        [HttpPost]
        public IActionResult SiparisEkle(int userId, [FromQuery] int[] productsIDs, [FromQuery] short[] quantities)
        {
            Order yeniSiparis = new Order();
            yeniSiparis.UserId = userId;
            yeniSiparis.Status = Status.Pending;
            yeniSiparis.IsActive = true;

            _orderService.Add(yeniSiparis);

            for (int i = 0; i < productsIDs.Length; i++)
            {
                OrderDetails yeniDetay = new OrderDetails();
                yeniDetay.OrderId = yeniSiparis.Id;
                yeniDetay.ProductId = productsIDs[i];
                yeniDetay.Quantity = quantities[i];
                yeniDetay.UnitPrice = _productService.GetById(productsIDs[i]).UnitPrice;
                yeniDetay.IsActive = true;

                _odService.Add(yeniDetay);

            }
            return Ok(yeniSiparis);
        }

        [HttpGet("{id}")]
        public IActionResult SiparisOnayla(int Id)
        {
            Order confirmedOrder = _orderService.GetById(Id);
            if (confirmedOrder == null)
            {
                return NotFound();
            }
            else
            {
                List<OrderDetails> detaylar = _odService.GetDefault(x => x.OrderId == confirmedOrder.Id).ToList();

                foreach (OrderDetails item in detaylar)
                {
                    Product productInOrder = _productService.GetById(item.ProductId);
                    productInOrder.Stock -= Convert.ToInt16(item.Quantity);
                    _productService.Update(productInOrder);
                }

                confirmedOrder.Status = Status.Confirmed;
                confirmedOrder.IsActive = false;
                _orderService.Update(confirmedOrder);

                return Ok(confirmedOrder);
            }
        }

        [HttpGet("{id}")]
        public IActionResult SiparisReddet(int Id)
        {
            Order cancelledOrder = _orderService.GetById(Id);
            if (cancelledOrder == null)
            {
                return NotFound();
            }
            else
            {
                cancelledOrder.Status = Status.Cancelled;
                cancelledOrder.IsActive = false;
                _orderService.Update(cancelledOrder);
                return Ok(cancelledOrder);
            }
        }
    }
}
