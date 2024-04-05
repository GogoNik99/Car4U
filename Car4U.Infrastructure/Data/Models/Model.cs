using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Car4U.Infrastructure.Constants.DataConstants;

namespace Car4U.Infrastructure.Data.Models
{
    [Comment("Car Model")]
    public class Model
    {
        [Key]
        [Comment("Brand Identifier")]

        public int Id { get; set; }

        [Required]
        [MaxLength(ModelNameMaxLenght)]
        [Comment("Model Name")]

        public string Name { get; set; } = string.Empty;

        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
