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
    
    public partial class CalendarUserRole
    {
        public CalendarUserRole()
        {
            this.CalendarUsersInRoles = new HashSet<CalendarUsersInRole>();
        }
    
        public int CalendarUserRoleId { get; set; }
        public string CalendarUserRoleName { get; set; }
    
        public virtual ICollection<CalendarUsersInRole> CalendarUsersInRoles { get; set; }
    }
}
