using System;
using System.Linq;
using System.Linq.Expressions;
using Todd.Domain;

namespace Todd.Interfaces
{
    public interface ICalendarRepository : IEntityRepository<Calendar>
    {

    }

    public interface ICalendarRefRepository : IEntityRepository<CalendarReferenceList>
    {

    }

    public interface ICalendarEventRepository : IEntityRepository<CalendarEvent>
    {

    }

    public interface IEntityRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void InsertOrUpdate(T entity);
        void Delete(int id);
        //void Save();
    }
}
