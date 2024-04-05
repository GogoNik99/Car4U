using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car4U.Infrastructure.Data.SeedDb
{
    public class FuelTypeConfiguration : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            var data = new SeedData();

            builder.HasData(data.Electric, data.Petrol, data.Gasoline, data.Diesel);
        }
    }
}
