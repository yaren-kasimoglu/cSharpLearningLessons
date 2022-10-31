using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly ProductApplicationContext _db;
        private DbSet<T> entities;

        public Repository(ProductApplicationContext db)
        {
            _db = db;
            entities = _db.Set<T>();
        }

        //insert, update, delete, getall, getbyid

        public void Insert(T entity)
        {
            entities.Add(entity);
            _db.SaveChanges();
        }

        public void Update()
        {
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            entities.Remove(entities.Find(id));
            _db.SaveChanges();
        }
        public IQueryable<T> GetAll()
        {
            return entities;
        }
        public T GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
