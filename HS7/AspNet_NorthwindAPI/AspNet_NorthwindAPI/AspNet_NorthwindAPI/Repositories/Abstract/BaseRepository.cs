using AspNet_NorthwindAPI.Models.dbContext;
using AspNet_NorthwindAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AspNet_NorthwindAPI.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {

      protected readonly NorthwindContext _context;
      protected readonly DbSet<T> _table;
        public BaseRepository(NorthwindContext context)
        {
            //this.context = context;
            _context = context;
            _table = _context.Set<T>();
        }


        public async Task<T> Add(T item)
        {
           var returnValue= await  _table.AddAsync(item);
            await _context.SaveChangesAsync();
            return returnValue.Entity;
        }


        public async Task<bool> Delete(T item)
        {
            var returnValue = _table.Remove(item);
           return _context.SaveChanges()>0;
           
        }

        public async Task<T> Edit(T item)
        {

            _table.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<List<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<List<T>> GetExpression(Expression<Func<T, bool>> expression)
        {
            return await  _table.Where(expression).ToListAsync();
        }
    }
}
