using AspNet_NorthwindAPI.Models.Entities;
using AspNet_NorthwindAPI.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AspNet_NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperManagerController : ControllerBase
    {
       readonly IShipperRepository _shipperRepository;
        public ShipperManagerController(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        [HttpGet]
        public async Task<List<Shipper>> Get()
        {
            return await _shipperRepository.GetAll();
        }


        [HttpPost]
        public async Task<Shipper> Post(Shipper item)
        {
            return await _shipperRepository.Add(item);
        }
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await _shipperRepository.Delete( await _shipperRepository.GetByID(id));
        }
        [HttpPut]
        public async Task<Shipper> Put(Shipper item)
        {
            return await _shipperRepository.Edit(item);
        }

    }
}
