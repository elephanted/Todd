using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todd.Domain;

namespace Todd.Data
{
    public class CalendarRefContext : BaseContext<CalendarRefContext>
    {       

        public virtual DbSet<CalendarReferenceList> CalendarReferenceLists { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalendarReferenceList>().ToTable("Calendars");
        }

    }
}
