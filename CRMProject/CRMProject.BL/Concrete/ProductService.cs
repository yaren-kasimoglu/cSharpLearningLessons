using CRMProject.BL.Abstract;
using CRMProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.BL.Concrete
{

    public class ProductService : IProductService
    {
        private IProductService _productService;
        public ProductService(IProductService productService)
        {
            _productService = productService;
        }
        public void Add(Product entity)
        {
            _productService.Add(entity);
        }

        public void Detele(Product entity)
        {
            _productService.Detele(entity);
        }

        public Product GetById(int id)
        {
           return _productService.GetById(id);
        }

        public IEnumerable<Product> Select(Expression<Func<Product, bool>> predicate = null)
        {
          return _productService.Select(predicate);
        }

        public void Update(Product entity)
        {
            _productService.Update(entity);
        }
    }
}
