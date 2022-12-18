using CRMProject.BL.Abstract;
using CRMProject.DAL.Abstract;
using CRMProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.BL.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryService _categoryService;
        public CategoryService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void Add(Category entity)
        {
            _categoryService.Add(entity);
        }

        public void Delete(Category entity)
        {
            _categoryService.Delete(entity);
        }

        public Category GetById(int id)
        {
            return _categoryService.GetById(id);
        }

        public IEnumerable<Category> Select(Expression<Func<Category, bool>> predicate = null)
        {
            return _categoryService.Select(predicate);
        }

        public void Update(Category entity)
        {
            _categoryService.Update(entity);
        }
    }
}
