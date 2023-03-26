using JWTWebApi.Domain.Entities.Concrete;
using JWTWebApi.Domain.Interfaces;
using JWTWebApi.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTWebApi.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task Add(Category item)
        {
            try
            {
                await _context.Categories.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Ekleme İşlemi Sırasında Bir Hata İle Karşılaşıldı.");
            }
        }

        public Task Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
