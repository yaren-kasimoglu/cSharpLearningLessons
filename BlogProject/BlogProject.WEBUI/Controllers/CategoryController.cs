using BlogProject.Core.Entity.Service;
using BlogProject.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.WEBUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICoreService<Category> _catService;
        private readonly ICoreService<Post> _postService;
        public CategoryController(ICoreService<Category> catService, ICoreService<Post> postService)
        {
            _catService = catService;
            _postService = postService;
        }
        public IActionResult Index()
        {
            return View(_catService.GetActive(x=>x.Posts).ToList());
        }

        public IActionResult PostList(Guid id)
        {
            ViewData["Title"]=_catService.GetById(id).CategoryName;

            return View(_postService.GetActive(x => x.User, x => x.Comments).Where(x => x.CategoryID == id).ToList());
        }
}
}
