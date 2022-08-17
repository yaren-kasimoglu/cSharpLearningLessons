using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS6_CRM_DAL.Abstract
{
    public interface IRepository<T> //Genel işlemler
    {
        //CRUD: Create- Read- Update- Delete

       //Ekleme
        void Insert(T item);
        //Update
        void Update(T item);
        //Delete
        bool Delete(int id);
        //Select
        T GetById(int id);
        //All Data
        List<T> GetAll();

        
    }
}
