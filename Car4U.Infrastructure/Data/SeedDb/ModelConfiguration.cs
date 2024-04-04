using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car4U.Infrastructure.Data.SeedDb
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            var data = new SeedData();

            builder.HasData(data.Peugeot, data.Opel, data.Citroen, data.KIA);
        }
    }
}
