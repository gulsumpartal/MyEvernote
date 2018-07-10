using MyEvernote.Common.Inıt;
using MyEvernote.DataAccessLayer.Abstract;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyEvernote.DataAccessLayer.EFRepositories
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        private readonly DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = db.Set<T>();
        }
        
        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public IQueryable<T> ListQueryableWithWhere(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).AsQueryable();
        }
        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable();
        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;

                o.CreatedOn = DateTime.Now;
                o.ModifiedUserName = AppCommon.Common.GetCurrentUserName();
                o.ModifiedOn = DateTime.Now;
                o.IsDeleted = false;
            }
            return Save();
        }

        public int Update(T obj)
        {
            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;

                o.ModifiedUserName = AppCommon.Common.GetCurrentUserName();
                o.ModifiedOn = DateTime.Now;
                o.IsDeleted = false;
            }
            return Save();
        }

        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
        
    }
}
