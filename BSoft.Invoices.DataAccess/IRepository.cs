using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.DataAccess
{
    public interface IRepository<T> where T : class
    {
        // Metodos Genericos
        bool Delete(T entity);
        bool Update(T entity);
        int Insert(T entity);
        IEnumerable<T> GetList();
        T GetById(int id);
    }
}
