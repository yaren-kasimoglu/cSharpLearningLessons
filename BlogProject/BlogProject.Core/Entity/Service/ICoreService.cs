using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Entity.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {

        bool Add(T item);
        bool Add(List<T> item);
        bool Remove(T item);
        bool Remove(Guid id);
        bool RemoveAll(Expression<Func<T,bool>> exp); //belli bir LINQ ifadesine göre filtreleyip silmek için yazılan servis metodu. MEtodun içine LINQ ifadesi verilecek
        bool Update(T item);
        T GetById(Guid id);
        T GetByDefault(Expression<Func<T,bool>> exp);//FirstOrDefault a benzer bir method oluştur demek.
        List<T> GetActive();
        List<T> GetDefault(Expression<Func<T,bool>> exp);
        List<T> GetAll();
        bool Activate(Guid id); //aktifleştirmek için kullanılacak method
        bool Any(Expression<Func<T,bool>> exp); //LINMQ ifadesi ile vcar mı diye sorgulama
        int Save(); //db de manipülasyon işleminden sonra 1 veya daha fazla satır eklendiğinde bize kaç satırın etkilendiğini döndürecek method

        IQueryable<T> GetActive(params Expression<Func<T, object>>[] includes);

        void DetachEntity(T item);
    }
}
