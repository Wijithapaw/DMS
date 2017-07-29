using Microsoft.EntityFrameworkCore;
using DMS.Data.Entities;
using System.Linq;
using System;
using DMS.Utills;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DMS.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        EnvironmentDescriptor _envDescriptor;

        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            _envDescriptor = new EnvironmentDescriptor { UserId = 1 }; //TODO get the correct user Id from DI
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectCategory> ProjectCategories { get; set; }

        public DbSet<Donee> Donees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProjectCategory>()
                .HasIndex(c => c.Title)
                .IsUnique(true);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            if (_envDescriptor != null)
            {
                foreach (var entry in this.ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added))
                {
                    entry.Entity.CreatedBy  = _envDescriptor.UserId;
                    entry.Entity.CreatedDate  = DateTime.UtcNow;
                    entry.Entity.LastUpdatedBy = _envDescriptor.UserId;
                    entry.Entity.LastUpdatedDate = DateTime.UtcNow;
                }

                foreach (var entry in this.ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Modified))
                {
                    entry.Entity.LastUpdatedBy = _envDescriptor.UserId;
                    entry.Entity.LastUpdatedDate = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }

    }
}
