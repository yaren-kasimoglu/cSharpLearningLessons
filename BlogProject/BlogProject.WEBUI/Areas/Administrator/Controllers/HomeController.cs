using BlogProject.Core.Entity.Service;
using BlogProject.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.WEBUI.Areas.Admnistrator.Controllers
{
    [Area("Administrator"), Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICoreService<User> _userService;
        private readonly ICoreService<Post> _postService;
        private readonly ICoreService<Category> _catService;
        private readonly ICoreService<Comment> _commentService;

        public HomeController(ILogger<HomeController> logger, ICoreService<Category> catService, ICoreService<User> userService, ICoreService<Post> postService, ICoreService<Comment> _commentService)
        {
            _logger = logger;
            this._userService = userService;
            this._postService = postService;
            this._catService = catService;
        }
        
        public IActionResult Index()
        {
            ViewBag.Kullanici = _userService.GetActive().Count;
            ViewBag.Kategori = _catService.GetActive().Count;
            ViewBag.Post = _postService.GetActive().Count;
            
           // ViewBag.Yorum = _commentService.GetActive().Count;
            return View();
        }
    }
}
