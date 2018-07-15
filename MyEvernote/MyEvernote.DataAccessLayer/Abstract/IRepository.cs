using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyEvernote.DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {

        List<T> List();

        IQueryable<T> ListQueryableWithWhere(Expression<Func<T, bool>> where);

        IQueryable<T> ListQueryable();

        int Insert(T obj);

        int Update(T obj);

        int Delete(T obj);

        int Save();

        T Find(Expression<Func<T, bool>> where);

        bool Any(Expression<Func<T, bool>> where);
    }
}
