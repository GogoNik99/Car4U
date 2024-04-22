using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Car4U.Infrastructure.Constants.DataConstants;

namespace Car4U.Infrastructure.Data.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [StringLength(RatingDecriptionMaxLenght)]
        [Comment("Rating Description")]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(OwnerRatingMinLenght, OwnerRatingMaxLenght)]
        [Comment("Rating value")]
        public decimal RatingValue { get; set; }

        [Required]
        [Comment("Owner Identifier")]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]

        public Owner Owner { get; set; } = null!;
    }
}
