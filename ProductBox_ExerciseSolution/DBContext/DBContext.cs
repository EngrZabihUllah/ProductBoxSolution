using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProductBox_ExerciseSolution.Models;

namespace ProductBox_ExerciseSolution.DBContext
{
    public class CustomerContext : DbContext
    {
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the model configuration for Customer and CustomerType entities
            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(1024);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(50);
                entity.Property(e => e.City).IsRequired().HasMaxLength(50);
                entity.Property(e => e.State).IsRequired().HasMaxLength(2);
                entity.Property(e => e.Zip).IsRequired().HasMaxLength(10);
                entity.HasOne(e => e.CustomerType).WithMany().HasForeignKey(e => e.CustomerTypeId);
            });
        }
    }
}