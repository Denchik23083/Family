﻿using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.Db
{
    public class FamilyContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }
        
        public DbSet<Child> Children { get; set; }

        public FamilyContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}