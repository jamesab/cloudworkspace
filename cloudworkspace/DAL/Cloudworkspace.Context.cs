﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cloudworkspaceEntities : DbContext
    {
        public cloudworkspaceEntities()
            : base("name=cloudworkspaceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AspNetRoleAspNetUser> AspNetRoleAspNetUsers { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
    }
}
