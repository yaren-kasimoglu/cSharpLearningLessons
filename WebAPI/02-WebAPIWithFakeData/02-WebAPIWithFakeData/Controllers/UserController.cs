using _02_WebAPIWithFakeData.Models;
using _02_WebAPIWithFakeData.Models.DummyData;
using Microsoft.AspNetCore.Mvc;

namespace _02_WebAPIWithFakeData.Controllers
{
    [Route("api/[controller]")] //buradaki route default olarak sunulur. ve url olarak https:localhost:portno/api/User şeklindedir.
    [ApiController]
    public class UserController : ControllerBase
    {

        //localhost:PortNo/api/User url ine get isteğinde bulunursak bruadaki Get() methodumuz tetiklenir.

        private List<User> _users = FakeData.GetUsers(200);
        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }


        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        [HttpPost]
        public User Post([FromBody] User user)
        {
            _users.Add(user);
            return user;
        }
        [HttpPut]
        public User Put([FromBody] User user)
        {
            var guncellenecek = Get(user.Id);
            guncellenecek.FirstName = user.FirstName;
            guncellenecek.LastName = user.LastName;
            guncellenecek.Address = user.Address;

            return user;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var silinecek = _users.FirstOrDefault(x => x.Id == id);
            if (silinecek!=null)
            {
                _users.Remove(silinecek);
                return "Kullanıcı listeden silindi";

            }
            else
            {
                return "Silinecek kullanıcı bulunamadı. Lütfen id bilgisini kontrol ediniz";
            }

        }
    }
}
