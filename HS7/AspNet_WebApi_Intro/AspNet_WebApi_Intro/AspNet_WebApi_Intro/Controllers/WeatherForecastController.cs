using AspNet_WebApi_Intro.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_WebApi_Intro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("kullanici")] // birden fazla get işlemi var ise route attirubute kullanarak bu işlemlerin urllerini ayırmamız gerekir.
        [HttpGet]
        public User GetUser()
        {

            return new User() { ID = 1, Name = "Rıdvan Aksoy", Age = "34" };
        }

        //Geri dönüş tipi önemlidir. bunun nedeni ise bu uygulamada yapılan işlemler en azından işlem tamamlandı mesajı vermelidir.
        //WebApi uygulamalarında bu tip actionlar oluşturmayız. bunun nedeni bize yapılan isteğin tamamlanıp tamamlanmadığını karşı tarafın alıp ona göre aksiyonlarını oluşturma zorunluluğudur.
        //oluşturulan actionlar basit yada zor algoritmalar içersede bir sonuç geri döndürmek zorundadır.
        //Aşağıdaki işlem yapısal olarak dogru, rumtime hatası vermeyen ve sonunda GetUser üzerinden sonuç döndürür. fakat karşı tarafın yaptığı isteği başka bir isteğe gönderip yani yönlendirip işlem yapmak doğru kabul edilemez. bu yüzden IslemYap actionı eğer isteği sonlandırırken kullanıcıları yönlendirme işlemi yapacaksa kendi scopeları arasında yapmalıdır.
        [Route("IslemYap")]
        public ActionResult IslemYap ()
        {
            return RedirectToAction("GetUser");
        }
    }
}