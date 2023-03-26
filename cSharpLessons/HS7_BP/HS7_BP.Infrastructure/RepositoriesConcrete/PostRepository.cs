using HS7_BP.Domain.Entities;
using HS7_BP.Domain.Repositories;
using HS7_BP.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Infrastructure.RepositoriesConcrete
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(BlogumDbContext dbContext) : base(dbContext)
        {

        }


    }
}
