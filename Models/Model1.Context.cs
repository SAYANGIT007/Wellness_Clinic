﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinicAutomation.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class myclinicEntities1 : DbContext
    {
        public myclinicEntities1()
            : base("name=myclinicEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<physician> physicians { get; set; }
        public virtual DbSet<prescription> prescriptions { get; set; }
        public virtual DbSet<schedule> schedules { get; set; }
        public virtual DbSet<appointment> appointments { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Chemist> Chemists { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<tbl_login> tbl_login { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
    }
}
