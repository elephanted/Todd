using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Todd.Domain
{
    [Table("Calendars")]
    public class CalendarReferenceList
    {
        [Key]
        public int CalendarId { get; set; }
        [StringLength(255)]
        public string CalendarName { get; set; }
        public string CalenderNamePlus 
        {
            get{ return string.Concat(CalendarName + " " + "Plus Something"); }
        }
    }
}
