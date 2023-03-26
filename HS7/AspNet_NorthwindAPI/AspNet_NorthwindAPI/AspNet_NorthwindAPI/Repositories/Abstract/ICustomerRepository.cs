using AspNet_NorthwindAPI.Models.Entities;

namespace AspNet_NorthwindAPI.Repositories.Abstract
{
    public interface ICustomerRepository:IBaseRepository<Customer>
    {

        Task<Customer> GetByIdCustomer(string id);
    }
}
