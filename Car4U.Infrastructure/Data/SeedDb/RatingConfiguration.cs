using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car4U.Infrastructure.Data.SeedDb
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder
               .HasOne(r => r.Owner)
               .WithMany(o => o.Ratings)
               .HasForeignKey(r => r.OwnerId)
               .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(data.Rating1, data.Rating2, data.Rating3, data.Rating4);
        }
    }
}
