using AspNet_NorthwindAPI.Models.dbContext;
using AspNet_NorthwindAPI.Models.Entities;
using AspNet_NorthwindAPI.Repositories.Abstract;

namespace AspNet_NorthwindAPI.Repositories.Concrete
{
    public class ShipperRepository:BaseRepository<Shipper>,IShipperRepository
    {
        public ShipperRepository(NorthwindContext context):base(context)
        {
            
        }


    }
}
