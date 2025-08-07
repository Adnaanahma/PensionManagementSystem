using Microsoft.EntityFrameworkCore;
using PensionManagementSystem.Application.Entities;

namespace PensionManagementSystem.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Contribution> Contributions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configurations if needed
            modelBuilder.Entity<Member>().HasKey(m => m.Id);
            modelBuilder.Entity<Benefit>().HasKey(m => m.Id);
            modelBuilder.Entity<Employer>().HasKey(m => m.Id);
            modelBuilder.Entity<Contribution>().HasKey(m => m.Id);
            // Add more configurations as needed
        }
    }
}
