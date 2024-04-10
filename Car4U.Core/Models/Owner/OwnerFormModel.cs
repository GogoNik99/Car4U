using System.ComponentModel.DataAnnotations;
using static Car4U.Core.Constants.MessageConstants;
using static Car4U.Infrastructure.Constants.DataConstants;

namespace Car4U.Core.Models.Owner
{
    public class OwnerFormModel
    {

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(OwnerPhoneNumberMaxLenght,
            MinimumLength = OwnerPhoneMinLength,
            ErrorMessage = LengthMessage)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(OwnerAddressMaxLenght,
            MinimumLength = OwnerAddressMinLenght,
            ErrorMessage = LengthMessage)]
        public string Address { get; set; } = string.Empty;
    }
}
