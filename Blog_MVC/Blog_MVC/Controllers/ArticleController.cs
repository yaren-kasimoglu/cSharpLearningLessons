using Blog_MVC.BL.Abstract;
using Blog_MVC.DAL.Concrete.Context;
using Blog_MVC.DTO.Concrete;
using Blog_MVC.DTO.Concrete.Account;
using Blog_MVC.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;

namespace Blog_MVC.Controllers
{
    public class ArticleController : Controller
    {
        BlogContext db = new BlogContext();

        public IActionResult List()
        {
            var article = db.Article.ToList();
            return View(article);
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddArticle(ArticleDTO articleDto)
        {
            Article article = new Article();
            article.ArticleId = articleDto.ArticleId;
            article.Title = articleDto.Title;
            article.Description = articleDto.Description;

           db.Article.Add(article);
            db.SaveChanges();

           return RedirectToAction("List", "Article");
        }

        [HttpGet("article-detail/{id?}")]
        public IActionResult ReadMoreArticle(int id)
        {
            if (id==null)
            {
                return NotFound();
            }
           // var article = _dbContext.Article.Where(x => x.ArticleId == id).FirstOrDefault();

            //if (article==null)
            //{
            //    return  NotFound();
            //}

            return View();
        }

    }
}
