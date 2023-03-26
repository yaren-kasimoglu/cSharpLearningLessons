using HS7_BP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Domain.Repositories
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        Task<List<Category>> DeactiveCategories();
    }
}
