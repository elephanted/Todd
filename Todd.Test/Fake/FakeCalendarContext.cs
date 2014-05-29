using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todd.Data;
using Todd.Domain;

namespace Todd.Test.Fake
{
    class FakeCalendarContext:ICalendarContext
    {
        public virtual IDbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual IDbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual IDbSet<CalendarEventDate> CalendarEventDates { get; set; }
        public virtual IDbSet<CalendarEvent> CalendarEvents { get; set; }
        public virtual IDbSet<Calendar> Calendars { get; set; }
        public virtual IDbSet<CalendarType> CalendarTypes { get; set; }
        public virtual IDbSet<CalendarUserRole> CalendarUserRoles { get; set; }
        public virtual IDbSet<CalendarUsersInRole> CalendarUsersInRoles { get; set; }
        public virtual IDbSet<RepeatType> RepeatTypes { get; set; }

        
        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void SetModified(object entity)
        {
            throw new NotImplementedException();
        }

        public void SetAdd(object entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}
