﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Karmolin_Fitness_Center_.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities1 : DbContext
    {
        public Entities1()
            : base("name=Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AttendanceRecords> AttendanceRecords { get; set; }
        public virtual DbSet<ListOfTrainers> ListOfTrainers { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SaleSubscription> SaleSubscription { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TrainerSpecialization> TrainerSpecialization { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}