using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class RepositoryBase<TEntity, TContext>
        where TContext : DbContext, new()
        where TEntity : BaseEntity, new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter=null, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        dbSet = dbSet.Include(item);
                    }
                }
                if (filter != null)
                    return dbSet.Where(filter).ToList();
                else
                    return dbSet.ToList();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        dbSet = dbSet.Include(item);
                    }
                }
                return dbSet.SingleOrDefault(filter);
            }
        }

        public TEntity GetById(int id, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                return Get(x => x.Id == id, includeList);
            }
        }


        public void Add(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                //ctx.Set<TEntity>().Add(entity);
                //ctx.SaveChanges();
                var obj = ctx.Entry(entity);
                obj.State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                var obj = ctx.Entry(entity);
                obj.State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
        public void DeleteById(int id)
        {
            using (TContext ctx = new TContext())
            {
                TEntity entity = GetById(id);
                if (entity != null)
                    Delete(entity);
                ctx.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                var obj = ctx.Entry(entity);
                obj.State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}