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

    public partial class PROJECT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROJECT()
        {
            this.CLIENT_PROJECT = new HashSet<CLIENT_PROJECT>();
            this.DELIVERABLES = new HashSet<DELIVERABLE>();
        }

        [Display(Name = "Project Name")]
        public string Name { get; set; }
        public int Project_ID { get; set; }
        [Display(Name = "USA Region")]
        public string USA_region { get; set; }
        public System.DateTime Deadline { get; set; }
        public decimal Budget { get; set; }
        [Display(Name = "Start Date")]
        public System.DateTime Start_date { get; set; }
        [Display(Name = "End Date")]
        public Nullable<System.DateTime> End_date { get; set; }
        [Display(Name = "Progress Status")]
        public string Progress_status { get; set; }
        [Display(Name = "Last Update")]
        public Nullable<System.DateTime> Last_update { get; set; }
        [Display(Name = "Last Update By")]
        public string Last_update_by { get; set; }
        public int Department_ID { get; set; }
        public int Manager_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENT_PROJECT> CLIENT_PROJECT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DELIVERABLE> DELIVERABLES { get; set; }
        public virtual DEPARTMENT DEPARTMENT { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}
