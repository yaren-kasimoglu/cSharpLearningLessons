using HS7_BP.Domain.Entities;
using HS7_BP.Domain.Repositories;
using HS7_BP.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Infrastructure.RepositoriesConcrete
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogumDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _categoryTable = _dbContext.Categories;
        }
        BlogumDbContext _dbContext;
        DbSet<Category> _categoryTable;

        public async Task<List<Category>> DeactiveCategories()
        {

            return await this.GetDefault(x => x.Status == Domain.Enums.Status.DeActive);
        }


    }
}
