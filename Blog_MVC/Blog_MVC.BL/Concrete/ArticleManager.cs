using Blog_MVC.BL.Abstract;
using Blog_MVC.DAL.Abstract;
using Blog_MVC.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MVC.BL.Concrete
{
    public class ArticleManager : IArticleManager
    {
        private readonly IArticleRepository _repo;

        public ArticleManager(IArticleRepository repo)
        {
            _repo = repo;
        }
    
        public void Add(Article entity)
        {
            _repo.Add(entity);
        }

        public void Delete(Article entity)
        {
           _repo.Delete(entity);
        }

        public Article GetById(int id)
        {
           return _repo.GetById(id);
        }

        public IEnumerable<Article> Select(Expression<Func<Article, bool>> predicate = null)
        {
            return _repo.Select(predicate);
        }

        public void Update(Article entity)
        {
            _repo.Update(entity);
        }
    }
}
