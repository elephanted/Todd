using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todd.Domain;

namespace Todd.Data
{
    public interface ICalendarContext : IContext
    {
        IDbSet<AspNetRole> AspNetRoles { get;  }
        IDbSet<AspNetUserClaim> AspNetUserClaims { get;  }
        IDbSet<AspNetUserLogin> AspNetUserLogins { get;  }
        IDbSet<AspNetUser> AspNetUsers { get;  }
        IDbSet<CalendarEventDate> CalendarEventDates { get;  }
        IDbSet<CalendarEvent> CalendarEvents { get;  }
        IDbSet<Calendar> Calendars { get;  }
        IDbSet<CalendarType> CalendarTypes { get;  }
        IDbSet<CalendarUserRole> CalendarUserRoles { get;  }
        IDbSet<CalendarUsersInRole> CalendarUsersInRoles { get;  }
        IDbSet<RepeatType> RepeatTypes { get;  }
    }

    public class CalendarContext : BaseContext<CalendarContext>, ICalendarContext
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

        public virtual DbSet<CalendarReferenceList> CalendarReferenceLists { get; set; }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetAdd(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }
    }
}
