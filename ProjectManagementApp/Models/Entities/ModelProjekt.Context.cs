﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagementApp.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ZarzadanieProjektami2Entities : DbContext
    {
        public ZarzadanieProjektami2Entities()
            : base("name=ZarzadanieProjektami2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BudzetProjektu> BudzetProjektu { get; set; }
        public virtual DbSet<HistoriaDzialanProjektu> HistoriaDzialanProjektu { get; set; }
        public virtual DbSet<LogiZadan> LogiZadan { get; set; }
        public virtual DbSet<NotatkiProjekty> NotatkiProjekty { get; set; }
        public virtual DbSet<NotatkiWydarzenia> NotatkiWydarzenia { get; set; }
        public virtual DbSet<PlikiProjekty> PlikiProjekty { get; set; }
        public virtual DbSet<PlikiWydarzenia> PlikiWydarzenia { get; set; }
        public virtual DbSet<PodsumowanieCzasu> PodsumowanieCzasu { get; set; }
        public virtual DbSet<Projekty> Projekty { get; set; }
        public virtual DbSet<RejestrCzasuPracyProjekt> RejestrCzasuPracyProjekt { get; set; }
        public virtual DbSet<RyzykaProjektu> RyzykaProjektu { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tagi> Tagi { get; set; }
        public virtual DbSet<Wydarzenia> Wydarzenia { get; set; }
        public virtual DbSet<Zadania> Zadania { get; set; }
    }
}