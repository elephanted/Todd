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


namespace Todd.Data.Models
{ 
    //public class CalendarAccessor
    //{
    //    private readonly UnitOfWork<CalendarContext> _uow;
    //    private readonly CalendarRepository _repo;
    //    public CalendarAccessor()
    //    {
    //     _uow= new UnitOfWork<CalendarContext>();
    //      _repo=new CalendarRepository(_uow);
            
    //    }

    //    public CalendarRepository Repo
    //    {
    //      get { return _repo; }
    //    }
    
    //    public void Save()
    //    {
    //      _uow.Save();
    //    }
    //}

    public class CalendarRepository : ICalendarRepository
    {
        //ToddEntities context = new ToddEntities();
        

        private readonly CalendarContext context;

        public CalendarRepository (IUnitOfWork  uow)
	    {
            context = uow.Context as CalendarContext;
            //context.Configuration.ProxyCreationEnabled = false;
            //context.Configuration.LazyLoadingEnabled = false;
	    }        
               

        public IQueryable<Calendar> All
        {   
            //var calendars = db.Calendars.Include(c => c.AspNetUser).Include(c => c.CalendarType);
            get { return context.Calendars; }

        }

        public IQueryable<Calendar> AllIncluding(params Expression<Func<Calendar, object>>[] includeProperties)
        {

            IQueryable<Calendar> query = context.Calendars;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Calendar Find(int id)
        {
            //return context.Calendars.Include(c => c.AspNetUser).Include(c => c.CalendarType).First(c=>c.CalendarId==id);
            return context.Calendars.Find(id);
        }

        public void InsertGraph(Calendar calendar)
        {
            context.Calendars.Add(calendar);
        }

        public void InsertOrUpdate(Calendar calendar)
        {
            
            if (calendar.CalendarId == default(int)) {
                // New entity
                context.Entry(calendar).State = EntityState.Added;
            } else {
                // Existing entity
                context.Calendars.Add(calendar);
                //context.Calendars.Attach(calendar);
                context.Entry(calendar).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var calendar = context.Calendars.Find(id);
            context.Calendars.Remove(calendar);
        }

        //public void Save()
        //{
        //    context.SaveChanges();
        //}

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    

    public class CalendarRefRepository  : ICalendarRefRepository
    {
        CalendarRefContext context;

        public CalendarRefRepository(UnitOfWorkCalendarRef uow)
	    {
            context = uow.Context;
            context.Configuration.ProxyCreationEnabled = false; 
	    }

        public IQueryable<CalendarReferenceList> All
        {
            get { return context.CalendarReferenceLists; }
        }

        public IQueryable<CalendarReferenceList> AllIncluding(params Expression<Func<CalendarReferenceList, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public CalendarReferenceList Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(CalendarReferenceList entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
    

    
}