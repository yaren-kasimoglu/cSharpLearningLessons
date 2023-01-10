using Blog_MVC.DAL.Abstract;
using Blog_MVC.DAL.Concrete.Context;
using Blog_MVC.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MVC.DAL.Concrete.Repository
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private BlogContext _dbContext;
        public ArticleRepository(BlogContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
