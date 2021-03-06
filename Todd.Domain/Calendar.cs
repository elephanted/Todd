//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Todd.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Todd.ObjectInterfaces;
    
    public partial class Calendar : Entity
    {
        public Calendar()
        {
            this.CalendarEvents = new HashSet<CalendarEvent>();
        }
    
        public int CalendarId { get; set; }
        public string CalendarName { get; set; }
        public Nullable<int> CalendarTypeId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string CreatedByUserId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }
        public virtual CalendarType CalendarType { get; set; }

        [NotMapped]
        public State State { get; set; }
        [NotMapped]
        public int _Id;
        public int Id 
        {
            get { return _Id; } 
            set { this._Id = CalendarId; } 
        }
    }
}
