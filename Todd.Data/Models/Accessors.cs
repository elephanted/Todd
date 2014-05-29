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
    //Accessor for the Calendar Entity
    public class CalendarAccessor
    {
        private readonly UnitOfWork<CalendarContext> _uow;
        private readonly Repository<Calendar> _repo;
        public CalendarAccessor()
        {
            _uow = new UnitOfWork<CalendarContext>();
            _repo = new Repository<Calendar>(_uow);
        }

        public Repository<Calendar> Repo
        {
            get { return _repo; }
        }

        public void Save()
        {
            _uow.Save();
        }
    }

    //Accessor for the CalendarEvent Entity
    public class CalendarEventAccessor
    {
        private readonly UnitOfWork<CalendarContext> _uow;
        private readonly Repository<CalendarEvent> _repo;
        public CalendarEventAccessor()
        {
            _uow = new UnitOfWork<CalendarContext>();
            _repo = new Repository<CalendarEvent>(_uow);
        }

        public Repository<CalendarEvent> Repo
        {
            get { return _repo; }
        }

        public void Save()
        {
            _uow.Save();
        }
    }

    //Accessor for the CalendarEventDate Entity
    public class CalendarEventDateAccessor
    {
        private readonly UnitOfWork<CalendarContext> _uow;
        private readonly Repository<CalendarEventDate> _repo;
        public CalendarEventDateAccessor()
        {
            _uow = new UnitOfWork<CalendarContext>();
            _repo = new Repository<CalendarEventDate>(_uow);
        }

        public Repository<CalendarEventDate> Repo
        {
            get { return _repo; }
        }

        public void Save()
        {
            _uow.Save();
        }
    }
}
