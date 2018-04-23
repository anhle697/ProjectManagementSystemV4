//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagementSystemV4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TIMESHEET
    {
        public int Timesheet_ID { get; set; }
        public System.DateTime Week { get; set; }
        public double Hours { get; set; }
        [Display(Name = "Last Update")]
        public Nullable<System.DateTime> Last_update { get; set; }
        [Display(Name = "Last Update By")]
        public string Last_update_by { get; set; }
        public int Employee_ID { get; set; }
        public int Deliverable_ID { get; set; }
    
        public virtual DELIVERABLE DELIVERABLE { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}
