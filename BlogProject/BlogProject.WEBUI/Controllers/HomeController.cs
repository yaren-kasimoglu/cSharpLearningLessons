using BlogProject.Core.Entity.Enum;
using BlogProject.Core.Entity.Service;
using BlogProject.Entities.Entities;
using BlogProject.WEBUI.Models;
using BlogProject.WEBUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogProject.WEBUI.Controllers
{
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
            //aktif olan postları döndür
            return View(_postService.GetActive());
        }

        public IActionResult PostsByCategoryID(Guid id) //category nin id si
        {
            //Kategori ıd ye göre active postları döndürelim
            return View(_postService.GetDefault(x=>x.CategoryID==id));
        }

        public IActionResult Post(Guid id)//gönderinin id si post un
        {
            //post u gösteriyoruz. Gösterirken de okunma sayısını (view count) 1 arttıralm.
            Post readPost = _postService.GetById(id);
            readPost.Viewcount++;
            _postService.Update(readPost);

            PostDetailVM vm = new PostDetailVM();
            vm.Post = readPost;
            vm.Category = _catService.GetById(readPost.CategoryID);
            vm.User=_userService.GetById(readPost.UserID);
           // vm.Comments = _commentService.GetDefault(x => x.PostID == readPost.ID).ToList();
            //vm.Comments = _commentService.GetDefault(x => x.Status == Status.Active && x.PostID == readPost.ID); //ÇALIŞMIYOR
            vm.Categories = _catService.GetActive();
           

            Random r = new Random();
           
            for (int i = 0; i < 3; i++)
            {
                vm.RelatedPost.Add(_postService.GetActive().ElementAt(r.Next(0, _postService.GetActive().Count())));
            }

            

            return View(vm); //view a döndürürken ilgili post u kategorisini yazarını (kullanıcıyı) döndürmemiz gerekiyor. Bu sebeple Tuple ya da view model yapısını kullanmalıyız.
        }


        public IActionResult SearchResult(string q)
        {
            ViewData["Title"] = "Ara: " + q;

            return View(_postService.GetActive(x => x.User, x => x.Comments).Where(x => x.Title.Contains(q) || x.PostDetail.Contains(q)).ToList());


            //return View(_postService.GetDefault(x => x.Title.Contains(q) || x.PostDetail.Contains(q)));
        }
    }
}