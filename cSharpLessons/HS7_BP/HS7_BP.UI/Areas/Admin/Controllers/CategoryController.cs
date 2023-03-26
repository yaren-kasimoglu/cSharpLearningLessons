using AutoMapper;
using HS7_BP.Application.Models.DTOs.CategoryDTOs;
using HS7_BP.Application.Services.CategoryRepository;
using HS7_BP.UI.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HS7_BP.Domain;
using System.Data;

namespace HSYedi_BP.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles ="Admin")]
    [Authorize(Roles = "admin")]

    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;


        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;

        }


        public IActionResult Index()
        {
            return View();
        }


        //Tüm aktif kategorileri Listeleyeceğiz.
        public async Task<IActionResult> GetAllCategories()
        {

            var listDTO = await _categoryService.GetDefaults(x => x.Status == HS7_BP.Domain.Enums.Status.Active);
            var listVM = _mapper.Map<List<CategoryListVM>>(listDTO);

            return View(listVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = _mapper.Map<CategoryCreateDTO>(vm);
                    _categoryService.Create(dto);
                    return RedirectToAction("GetAllCategories");

                }
                catch (Exception ex)
                {

                    TempData["error"] = ex.Message;
                }
            }

            return View(vm);
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.Remove(id);
                return RedirectToAction("GetAllCategories");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllCategories");

            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var updateDto = await _categoryService.GetById(id);
            var updateVm = _mapper.Map<CategoryEditVM>(updateDto);

            return View(updateVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditVM vm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var updateDto = _mapper.Map<CategoryUpdateDTO>(vm);
                    await _categoryService.Edit(updateDto);
                    return RedirectToAction("GetAllCategories");
                }
                catch (Exception ex)
                {

                    TempData["error"] = ex.Message;
                }
            }

            return View(vm);
        }

    }
}
