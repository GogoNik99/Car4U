using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car4U.Infrastructure.Data.SeedDb
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder
               .HasOne(v => v.FuelType)
               .WithMany(f => f.Vehicles)
               .HasForeignKey(v => v.FuelTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(v => v.Model)
                .WithMany(m => m.Vehicles)
                .HasForeignKey(v => v.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(v => v.Owner)
                .WithMany(o => o.Vehicles)
                .HasForeignKey(v => v.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(data.ThirdVehicle, data.SecondVehicle, data.FirstVehicle, data.FourthVehicle);
        }
    }
}
