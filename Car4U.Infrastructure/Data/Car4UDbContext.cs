using Car4U.Infrastructure.Data.Models;
using Car4U.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Data.Infrastructure
{
    public class Car4UDbContext : IdentityDbContext<ApplicationUser>
    {
        private bool _seedDb;
        public Car4UDbContext(DbContextOptions<Car4UDbContext>
            options, bool seedDb = true) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }
            _seedDb = seedDb;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (_seedDb)
            {
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new OwnerConfiguration());
                builder.ApplyConfiguration(new FuelTypeConfiguration());
                builder.ApplyConfiguration(new ModelConfiguration());
                builder.ApplyConfiguration(new VehicleConfiguration());
                builder.ApplyConfiguration(new RatingConfiguration());
            }

            base.OnModelCreating(builder);
        }

        public DbSet<Owner> Owners { get; set; } = null!;

        public DbSet<Model> Models { get; set; } = null!;

        public DbSet<Vehicle> Vehicles { get; set; } = null!;

        public DbSet<FuelType> FuelTypes { get; set; } = null!;

        public DbSet<Rating> Ratings { get; set; } = null!;
    }
}