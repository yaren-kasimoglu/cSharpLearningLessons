using Bogus;

namespace _02_WebAPIWithFakeData.Models.DummyData
{
    public class FakeData
    {
        private static List<User> _users;

        public static List<User> GetUsers(int count)//kaç tane users oluşturmak istediğimzii parametre olarak göndeiryoruz
        {
            if (_users==null)
            {
                _users = new Faker<User>()
              .RuleFor(x => x.Id, faker => faker.IndexFaker + 1)
              .RuleFor(x => x.FirstName, faker => faker.Name.FirstName())
              .RuleFor(x => x.LastName, faker => faker.Name.LastName())
              .RuleFor(x => x.Address, faker => faker.Address.FullAddress())
              .Generate(count);
            }
            return _users;
        }

    }
}
