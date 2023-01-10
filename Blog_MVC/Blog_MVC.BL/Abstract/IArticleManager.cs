using Blog_MVC.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MVC.BL.Abstract
{
    public interface IArticleManager
    {
        Article GetById(int id);
        void Add(Article entity);
        void Update(Article entity);
        void Delete(Article entity);
        IEnumerable<Article> Select(Expression<Func<Article, bool>> predicate = null);
    }
}
