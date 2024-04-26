using System.ComponentModel.DataAnnotations;
using static Car4U.Core.Constants.MessageConstants;
using static Car4U.Infrastructure.Constants.DataConstants;

namespace Car4U.Core.Models.Rating
{
    public class RatingFormViewModel
    {

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            OwnerMinRating,
            OwnerMaxRating,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = PriceRangeMessage)]
        public decimal RatingValue { get; set; }

        [StringLength(RatingDecriptionMaxLenght,
            MinimumLength = RatingDecriptionMinLenght,
            ErrorMessage = LengthMessage)]
        public string? Description { get; set; }
    }
}
