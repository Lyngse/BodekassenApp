﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bodekassen.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BodekassenDBContainer : DbContext
    {
        public BodekassenDBContainer()
            : base("name=BodekassenDBContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Team> TeamSet { get; set; }
        public virtual DbSet<Player> PlayerSet { get; set; }
        public virtual DbSet<FineType> FineTypeSet { get; set; }
        public virtual DbSet<Fine> FineSet { get; set; }
        public virtual DbSet<Match> MatchSet { get; set; }
        public virtual DbSet<Goal> GoalSet { get; set; }
        public virtual DbSet<MOTM> MOTMSet { get; set; }
        public virtual DbSet<Vote> VoteSet { get; set; }
    }
}