using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.Db
{
    public class FamilyContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; } = null!;

        public DbSet<Child> Children { get; set; } = null!;

        public DbSet<ParentsChildren> ParentsChildren { get; set; } = null!;

        public DbSet<Gender> Genders { get; set; } = null!;

        public DbSet<Genus> Genus { get; set; } = null!;

        public FamilyContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
