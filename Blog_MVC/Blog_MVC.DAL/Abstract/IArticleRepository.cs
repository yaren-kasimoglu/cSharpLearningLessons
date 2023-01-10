using Blog_MVC.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MVC.DAL.Abstract
{
    public interface IArticleRepository:IGenericRepository<Article>
    {
    }
}
