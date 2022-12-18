using CRMProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.BL.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);
        void Add(Category entity);
        void Update(Category entity);
        void Delete(Category entity);

        IEnumerable<Category> Select(Expression<Func<Category, bool>> predicate=null);
    }
}
