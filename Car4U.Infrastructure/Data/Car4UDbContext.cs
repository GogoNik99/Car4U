using Car4U.Infrastructure.Data.Models;
using Car4U.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Data.Infrastructure
{
    public class Car4UDbContext : IdentityDbContext
    {
        public Car4UDbContext(DbContextOptions<Car4UDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new OwnerConfiguration());
            builder.ApplyConfiguration(new FuelTypeConfiguration());
            builder.ApplyConfiguration(new ModelConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Owner> Owners { get; set; } = null!;

        public DbSet<Model> Models { get; set; } = null!;

        public DbSet<Vehicle> Vehicles { get; set; } = null!;

        public DbSet<FuelType> FuelTypes { get; set; } = null!;
    }
}