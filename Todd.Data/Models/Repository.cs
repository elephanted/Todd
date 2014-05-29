using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Todd.Domain;
using Todd.Interfaces;
using Todd.Data;
using Todd.ObjectInterfaces;

namespace Todd.Data.Models
{

    public class Repository<TEntity> where TEntity : Entity //: ICalendarRepository
    {
        private readonly CalendarContext context;
        private readonly IDbSet<TEntity> _dbSet;

        public Repository(IUnitOfWork uow)
        {
            context = uow.Context as CalendarContext;
            context.Configuration.ProxyCreationEnabled = false;

            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> All
        {
            get { return _dbSet.AsQueryable<TEntity>(); }
        }

        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public void InsertGraph(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Insert(TEntity entity)
        {
            ((IObjectWithState)entity).State = State.Added;
            _dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Added;
        }



        public virtual void Update(TEntity entity) 
        {
            var entry = context.Entry<TEntity>(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = context.Set<TEntity>();
                TEntity attachedEntity = set.Local.SingleOrDefault(e => e.Id == entity.Id);  // You need to have access to key

                if (attachedEntity != null)
                {
                    var attachedEntry = context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }

            
            //((IObjectWithState)entity).State = State.Modified;
            ////_dbSet.Attach(entity);
            //context.Entry(entity).State = EntityState.Modified;                        
        }
                
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity); ;
        }

        public virtual void Delete(TEntity entity)
        {
            ((IObjectWithState)entity).State = State.Deleted;
            _dbSet.Attach(entity); //Remove?
            //_dbSet.Remove(entity);
            context.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
