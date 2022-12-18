using CRMProject.DAL.Abstract;
using CRMProject.DAL.Concrete.EF.Context;
using CRMProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.DAL.Concrete.EF.Repository
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        private CRMContext _dbcontext;
        public ProductRepository(CRMContext dbcontext):base(dbcontext)
        {
            dbcontext = _dbcontext;
        }
    }
}
