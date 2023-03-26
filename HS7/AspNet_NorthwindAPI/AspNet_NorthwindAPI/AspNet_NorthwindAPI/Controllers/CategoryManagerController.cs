using AspNet_NorthwindAPI.Models.Entities;
using AspNet_NorthwindAPI.Repositories.Abstract;
using AspNet_NorthwindAPI.Repositories.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_NorthwindAPI.Controllers
{
    //[DisableCors]
    [ApiController]
    [Route("api/[controller]")]//[controller] kullanımı ise her hangi bir controller kendi adı ile temsil edilir.
    public class CategoryManagerController:ControllerBase
    {
        readonly ICategoryRepository _categoryRepository;
        public CategoryManagerController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //Get,Post-> Put ve Delete


        //Eğer controllerda herhangi bir metot belirlemezseniz tüm metotlarınız HttpGet olarak işaretlenmiş sayılır. buda birden fazla cevap verebileceği metot bulunmasından gelen her getRequest isteğine hata ile cevap vermesine neden olacaktır. fakar siz http metotlarını kullanmadan Route yani url tanımlama işlemi ile birden fazla get metodunuzu birbirinden ayırabilirsiniz.



        //Route  kullanırken "/" koymamak demek urlin başlangıcının Controller olduğunu kabul etmek demek. "/" eklersek controllerdan bagımsız domainadi/routeadi yönlendirmesi uygulanacaktır.



        //http://localhost:5292/CategoryManager/Kategoriler
        [HttpGet]
        [Route("Kategoriler")]
        public Task<List<Category>> Get()
        {
            return _categoryRepository.GetAll();
        }

        [HttpGet]
        //http://localhost:5292/Kategori/2
        [Route("/Kategori/{id}")]
        public Task<Category> Get(int id)
        {
            return _categoryRepository.GetByID(id);
        }

        [EnableCors]
        [HttpGet]
        public Task<List<Category>> Categories()
        {
            return _categoryRepository.GetAll();
        }

      
        [HttpPost]
        public async Task<Category> Post(Category item)
        {
          return await  _categoryRepository.Add(item);
        }
        [HttpPut]
        public async Task<Category> Put(Category item)
        {
            return await _categoryRepository.Edit(item);
        }


        //Route=> domain/api/CategoryController?id=1
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            var item = await _categoryRepository.GetByID(id);
            return await _categoryRepository.Delete(item);
        }

        [EnableCors]
        [Route("/ServerSaati")]
        [HttpGet]
        public DateTime ServerSaati()
        {
            return DateTime.Now;
        }


        [EnableCors]
        [Route("/hangisayibuyuk")]
        [HttpPost]
        public string ServerSaati(int sayi1,int sayi2)
        {
            return sayi1 > sayi2 ? $"{sayi1} büyüktür {sayi2} den" : $"{sayi2} büyüktür {sayi1} den";
        }

    }
}
