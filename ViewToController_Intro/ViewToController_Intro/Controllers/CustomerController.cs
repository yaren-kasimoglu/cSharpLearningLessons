using Microsoft.AspNetCore.Mvc;
using ViewToController_Intro.Models;

namespace ViewToController_Intro.Controllers
{
    public class CustomerController : Controller
    {
        private static List<CustomerVM> customers = new List<CustomerVM>()
        {
            new CustomerVM(){Id=1,Name="Yaren Kasımoğlu",Phone="05436097030",Address="İzmit"},
            new CustomerVM(){Id=2,Name="Emre Özbaşkan",Phone="05556097031",Address="Eyüp"},
            new CustomerVM(){Id=3,Name="Yunus Emre Teke",Phone="05436096666",Address="Sivas"},
            new CustomerVM(){Id=4,Name="Selim Akay",Phone="05436077777",Address="Bahçelievler"}
        };

        [Route("customer-list")]
        public IActionResult CustomerList()
        {
            return View(customers);
        }

        [Route("customer-detail/{id}")]
        public IActionResult CustomerDetail(int id)
        {
            var customer = customers.FirstOrDefault(x => x.Id == id);
        
            return View(customer);
        }

        [HttpPost]
        [Route("customer-detail/{id}")]
        public IActionResult CustomerDetail(int id, CustomerVM customer)
        {
            var findcustomer = customers.FirstOrDefault(x => x.Id == id);
            if (findcustomer != null)
            {
                findcustomer.Name = customer.Name;
                findcustomer.Phone = customer.Phone;
                findcustomer.Address = customer.Address;
            }
            return View(findcustomer);
        }
    }
}
