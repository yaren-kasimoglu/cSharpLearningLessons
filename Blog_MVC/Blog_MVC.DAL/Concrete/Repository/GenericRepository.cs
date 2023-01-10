using Blog_MVC.DAL.Abstract;
using Blog_MVC.DAL.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MVC.DAL.Concrete.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BlogContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(BlogContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }
            else
            {
                return _dbSet;
            }
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
    }
