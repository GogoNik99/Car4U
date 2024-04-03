using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Car4U.Infrastructure.Constants.DataConstants;

namespace Car4U.Infrastructure.Data.Models
{
    [Comment("Vehicle FuelType")]
    public class FuelType
    {
        [Key]
        [Comment("FuelType Identifier")]

        public int Id { get; set; }

        [Required]
        [MaxLength(FuelTypeNameMaxLength)]
        [Comment("FuelType Name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
