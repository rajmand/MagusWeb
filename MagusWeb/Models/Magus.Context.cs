﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagusWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MagusEntities : DbContext
    {
        public MagusEntities()
            : base("name=MagusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<Psi> Psi { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<MagusClass> MagusClass { get; set; }
        public virtual DbSet<Cube> Cube { get; set; }
    }
}
