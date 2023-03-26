using AspNet_NorthwindAPI.Models.dbContext;
using AspNet_NorthwindAPI.Models.Entities;
using AspNet_NorthwindAPI.Repositories.Abstract;

namespace AspNet_NorthwindAPI.Repositories.Concrete
{
    public class CustomerRepository:BaseRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(NorthwindContext context):base(context)
        {
            
        }

       public async Task<Customer> GetByIdCustomer(string id)
        {
            return await _table.FindAsync(id);
        }
    }
}
