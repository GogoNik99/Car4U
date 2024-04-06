using System.ComponentModel.DataAnnotations;
using static Car4U.Core.Constants.MessageConstants;
using static Car4U.Infrastructure.Constants.DataConstants;
namespace Car4U.Core.Models.Vehicle
{
    public class VehicleServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ModelNameMaxLenght,
            MinimumLength = ModelNameMinLenght,
            ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleManufacturerMaxLenght,
            MinimumLength = VehicleManufacturerMinLenght,
            ErrorMessage = LengthMessage)]
        public string Manifacturer { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleDescriptionMaxLenght,
            MinimumLength = VehicleDescriptionMinLenght,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            VehicleMinPrice,
            VehicleMaxPrice,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = RangeMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string ImageFileName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            OwnerMinRating,
            OwnerMaxRating,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = RangeMessage)]
        public decimal Rating { get; set; }

        public bool IsRented { get; set; }
    }
}
