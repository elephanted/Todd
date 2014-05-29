using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todd.Data
{
    public class UnitOfWorkCalendarRef
    {
        private readonly CalendarRefContext _context;

        public UnitOfWorkCalendarRef()
        {
            _context = new CalendarRefContext();
        }

        public UnitOfWorkCalendarRef(CalendarRefContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        internal CalendarRefContext Context
        {
            get { return _context; }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
