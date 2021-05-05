using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null); //  buradaki mantık; sana bir filtre verilirse onu getir, verilmez ise tümünü getir. 
        T Get(Expression<Func<T, bool>> filter); //burada tek bir data getirmek için filtre zorunlu dedik. Null Olamaz!!
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);   

    }
}
