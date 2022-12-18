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
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        private CRMContext _dbcontext;
        public CategoryRepository(CRMContext dbcontext):base(dbcontext)
        {
            dbcontext = _dbcontext;
        }
    }
}
