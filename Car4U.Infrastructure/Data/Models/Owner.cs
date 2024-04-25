using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Car4U.Infrastructure.Constants.DataConstants;

namespace Car4U.Infrastructure.Data.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Comment("Owner of the Car")]
    public class Owner
    {
        [Key]
        [Comment("Owner Identifier")]

        public int Id { get; set; }
        [Required]
        [MaxLength(OwnerPhoneNumberMaxLenght)]
        [Comment("Owner's phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(OwnerAddressMaxLenght)]
        [Comment("Owner's Address")]

        public string Address { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(OwnerRatingMinLenght, OwnerRatingMaxLenght)]
        [Comment("Owner's Rating")]
        public decimal Rating { get; set; }

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]

        public ApplicationUser User { get; set; } = null!;

        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public IEnumerable<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
