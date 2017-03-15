using Microsoft.EntityFrameworkCore;
using DMS.Data.Entities;

namespace DMS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectCategory> ProjectCategories { get; set; }

        public DbSet<Donor> Donors { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Donee> Donees { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProjectCategory>()
                .HasIndex(c => c.ShortDescription)
                .IsUnique(true);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public void Intialize()
        {
            //Apply any pending migrations
            Database.Migrate();
        }
    }
}
