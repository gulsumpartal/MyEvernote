using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyEvernote.DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {

        List<T> List();

        IQueryable<T> List(Expression<Func<T, bool>> where);

        int Insert(T obj);

        int Update();

        int Delete(T obj);

        int Save();

        T Find(Expression<Func<T, bool>> where);
    }
}
