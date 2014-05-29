using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todd.Data
{
    public class UnitOfWorkCalendar
    {
        private readonly CalendarContext _context;

        public UnitOfWorkCalendar()
        {
            _context = new CalendarContext();
        }

        public UnitOfWorkCalendar(CalendarContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        internal CalendarContext Context
        {
            get { return _context; }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
