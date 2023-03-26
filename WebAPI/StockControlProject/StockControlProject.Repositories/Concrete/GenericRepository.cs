﻿using Microsoft.EntityFrameworkCore;
using StockControlProject.Entities.Entities;
using StockControlProject.Repositories.Abstract;
using StockControlProject.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace StockControlProject.Repositories.Concrete
{
    public class GenericRepository<T>:IGenericRepository<T> where T : BaseEntity
    {
            private readonly StockControlContext _context;
            public GenericRepository(StockControlContext context)
            {
                _context = context;
            }


            public bool Add(T item)
            {
                //_context.Posts.Add();

                try
                {
                    item.AddedDate = DateTime.Now;
                    _context.Set<T>().Add(item);
                    return Save() > 0; // 1 satır etkileniyorsa true döndürsün.
                }
                catch (Exception)
                {

                    return false;
                }

            }

            public bool Add(List<T> items)
            {
                try
                {
                    using (TransactionScope ts = new TransactionScope())
                    {

                        //_context.Set<T>().AddRange(items);
                        foreach (T item in items)
                        {
                            item.AddedDate = DateTime.Now;
                            _context.Set<T>().Add(item);
                        }
                        ts.Complete(); // Tüm işlemler başarılı olduğunda, yani tüm ekleme işlemleri başarılı olduğunda Complete() olmuş olacak.
                        return Save() > 0; // 1 veya daha fazla satır ekleniyorsa..
                    }
                }
                catch (Exception)
                {

                    return false;
                }
            }

            public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);

            public List<T> GetActive() => _context.Set<T>().Where(x => x.IsActive == true).ToList();

            //buraya ekle
            public IQueryable<T> GetActive(params Expression<Func<T, object>>[] includes)
            {
                var query = _context.Set<T>().Where(x => x.IsActive == true);
                if (includes != null)
                {
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                }
                return query;
            }

            public List<T> GetAll() => _context.Set<T>().ToList();

            public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
            {
                var query = _context.Set<T>().Where(x => x.IsActive == true);
                if (includes != null)
                {
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                }
                return query;
            }

            public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().FirstOrDefault(exp);


            public T GetById(int id) => _context.Set<T>().Find(id);


            public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();


            public bool Remove(T item)
            {
                item.IsActive = false;
                return Update(item);
            }

            public bool Remove(int id)
            {
                try
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        T item = GetById(id);
                        item.IsActive = false;
                        return Update(item);
                    }
                }
                catch (Exception)
                {

                    return false;
                }
            }

            public bool RemoveAll(Expression<Func<T, bool>> exp)
            {
                try
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        var collection = GetDefault(exp); // Verilen ifadeye göre ilgili nesneleri collection'a atıyoruz.
                        int counter = 0;
                        foreach (var item in collection)
                        {
                            item.IsActive = false;
                            bool operationResult = Update(item); // DB'den silmiyoruz, durumunu silindi ayarlıyoruz ve bunu da update metodu ile gerçekleştiriyoruz.
                            if (operationResult) counter++; // Sıradki item'ın silinme işlemi(yani silindi işaretleme) başarılı ise sayacı 1 artırıyoruz.

                        }
                        if (collection.Count == counter) ts.Complete(); // Koleksiyondaki eleman sayısı ile silinme işlemi gerçekleşen eleman sayısı eşit ise bu işlemler başarılıdır.
                        else return false; // aksi halde hiçbirinde bir değişiklik yapmadan false döndürür.


                    }
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

            public int Save()
            {
                return _context.SaveChanges();
            }

            public bool Update(T item)
            {
                try
                {
                    //item.IsActive = true;
                    item.ModifiedDate = DateTime.Now;
                    _context.Set<T>().Update(item);
                    return Save() > 0;

                }
                catch (Exception)
                {

                    return false;
                }
            }
            public bool Activate(int id)
            {
                T item = GetById(id);
                item.IsActive = true;
                return Update(item);
            }
            public void DetachEntity(T item)
            {
                _context.Entry<T>(item).State = EntityState.Detached; // Bir entry'i takip etmeyi bırakmak için kullanılır.
            }

        public IQueryable<T> GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(x => x.Id == id);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
    }
}
