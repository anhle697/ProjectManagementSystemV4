﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjectManagementSystemEntities : DbContext
    {
        public ProjectManagementSystemEntities()
            : base("name=ProjectManagementSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CLIENT> CLIENTs { get; set; }
        public virtual DbSet<CLIENT_PROJECT> CLIENT_PROJECT { get; set; }
        public virtual DbSet<DELIVERABLE> DELIVERABLES { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTs { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<EMPLOYEE_DELIVERABLE> EMPLOYEE_DELIVERABLE { get; set; }
        public virtual DbSet<EMPLOYEE_TYPES> EMPLOYEE_TYPES { get; set; }
        public virtual DbSet<PROJECT> PROJECTs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TIMESHEET> TIMESHEETs { get; set; }
        public virtual DbSet<User_login> User_login { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Report_AllProjects> Report_AllProjects { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
    }
}
