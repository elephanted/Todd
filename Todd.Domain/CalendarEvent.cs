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

    public partial class CalendarEvent : Entity
    {
        public CalendarEvent()
        {
            this.CalendarEventDates = new HashSet<CalendarEventDate>();
        }
    
        public int CalendarEventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int CalendarId { get; set; }
    
        public virtual ICollection<CalendarEventDate> CalendarEventDates { get; set; }
        public virtual Calendar Calendar { get; set; }

        [NotMapped]
        public State State { get; set; }
        [NotMapped]
        public int _Id;
        public int Id
        {
            get { return _Id; }
            set { this._Id = CalendarEventId; }
        }
    }
}