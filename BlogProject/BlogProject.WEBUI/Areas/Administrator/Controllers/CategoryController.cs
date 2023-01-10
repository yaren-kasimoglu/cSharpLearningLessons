using BlogProject.Core.Entity.Service;
using BlogProject.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.WEBUI.Areas.Administrator.Controllers
{
    [Area("Administrator"), Authorize]
    public class CategoryController : Controller
    {
        private readonly ICoreService<Category> _categoryservice;

        public CategoryController(ICoreService<Category> categoryservice)
        {
            _categoryservice = categoryservice;
        }
        public IActionResult Index()
        {
            return View(_categoryservice.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            category.Status = Core.Entity.Enum.Status.None;   

            #region ModelState


            if (ModelState.IsValid)
            {
                bool result = _categoryservice.Add(category);
                if (result)
                {
                    TempData["MessageSuccess"] = $"Kayıt işlemi başarılı.";
                    return RedirectToAction("Index");//ekleme işlemi başarılıysa Index e dönsün
                }
                else
                {
                    TempData["MessageError"] = $"Kayıt işlemi sırasında bir hata meydana geldi. Lütfen tüm alanları kontrol edip tekrar deneyin.";
                }
            }
            else
            {
                TempData["MessageError"] = $"İşlem başarısız oldu.Lütfen tüm alanları kontrol edip tekrar deneyin.";
            }
            #endregion
            return View(category);//ekleme işlemi esnasında kullanılan category bilgileriyle view a döndürmesini sağlarız
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            return View(_categoryservice.GetById(id));
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {

            if (ModelState.IsValid)
            {
                Category updatedCategory=_categoryservice.GetById(category.ID);
                updatedCategory.Description = category.Description;
                updatedCategory.CategoryName = category.CategoryName;
                updatedCategory.Status = Core.Entity.Enum.Status.Updated;

                bool result = _categoryservice.Update(updatedCategory);
                if (result)
                {
                    //TempData["MessageSuccess"] = $"Kayıt işlemi başarılı.";
                    return RedirectToAction("Index");//ekleme işlemi başarılıysa Index e dönsün
                }
                else
                {
                    TempData["MessageError"] = $"Kayıt işlemi sırasında bir hata meydana geldi. Lütfen tüm alanları kontrol edip tekrar deneyin.";
                }
            }
            else
            {
                TempData["MessageError"] = $"İşlem başarısız oldu.Lütfen tüm alanları kontrol edip tekrar deneyin.";
            }
            return View(category);//ekleme işlemi esnasında kullanılan category bilgileriyle view a döndürmesini sağlarız
            return View();
        }
        public IActionResult Activate(Guid id)
        {
            _categoryservice.Activate(id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            _categoryservice.Remove(_categoryservice.GetById(id));
            return RedirectToAction("Index");
        }


    }
}
