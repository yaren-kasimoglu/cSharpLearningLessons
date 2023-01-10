using BlogProject.Core.Entity;
using BlogProject.Core.Entity.Service;
using BlogProject.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BlogProject.Core.Entity.Enum;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private readonly BlogProjectContext _context;

        public BaseService(BlogProjectContext context)
        {
            _context = context;
        }
        public bool Add(T item)
        {
            try
            {
                _context.Set<T>().Add(item);
                return Save() > 0; // 1 satır etkilendiyse true dönecek
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
                    _context.Set<T>().AddRange(items);
                    ts.Complete();//tüm işlemler olduğunda yani tüm ekleme işlemleri başarılı olduğunda Comlete() olmuş olacak.
                    return Save() > 0;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);


        public List<T> GetActive()
        {
            return _context.Set<T>().Where(x => x.Status == Core.Entity.Enum.Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().FirstOrDefault(exp);
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public bool Remove(T item)
        {
            item.Status = Status.Deleted;
            return Update(item);

        }

        public bool Remove(Guid id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    T item = GetById(id);
                    item.Status = Status.Deleted;
                    ts.Complete();
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
                    var collestion = GetDefault(exp);//verlen ifadeye göre ilgili itemları collectionda tutuyoruz
                    int counter = 0;
                    foreach (T item in collestion)
                    {
                        item.Status = Status.Deleted;
                        bool operationResult = Update(item); //db den silmiyoruz. Durumunu silindi ayarlıyoruz
                        if (operationResult)
                        {
                            counter++; //sıradaki item ın silinmme işlemi yan silindi işaretleme, başarılı ise sayacı 1 arttırıyoruz.
                        }
                    }
                    if (collestion.Count == counter)
                    {
                        ts.Complete(); //koleksiyondaki eleman sayısı ile silinme işlemi gerçekleşen eleman sayısı eşit ise işlemş tamamlandı aldıla. Başarılı.
                    }
                    else
                    {
                        return false;//aksi halde hiç birinde bir değişiklik yapmadan false döndürür
                        return false;//aksi halde hiç birinde bir değişiklik yapmadan false döndürür
                    }
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
                _context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Activate(Guid id)
        {
            T item = GetById(id);
            item.Status = Status.Active;
            return Update(item);
        }

        public void DetachEntity(T item)
        {
            _context.Entry<T>(item).State=EntityState.Detached;//bir entry yi takip etmeyi bırakmak için kullanılır.
        }

        public IQueryable<T> GetActive(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(x => x.Status == Core.Entity.Enum.Status.Active);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
    }
}
