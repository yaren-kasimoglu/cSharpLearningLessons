using AspNet_NorthwindAPI.Models.Entities;
using System.Linq.Expressions;

namespace AspNet_NorthwindAPI.Repositories.Abstract
{
    public interface IBaseRepository<T> where T:class,IEntity
    {
        Task<T> Add(T item);
        Task<T> Edit(T item);
        Task<bool> Delete(T item);
        Task<List<T>> GetAll();
        Task<T> GetByID(int id);
        Task<List<T>> GetExpression(Expression<Func<T, bool>> expression);
    }
}
