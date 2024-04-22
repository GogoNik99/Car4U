using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Car4U.Infrastructure.Constants.DataConstants;
namespace Car4U.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(UserFirstNameMaxLenght)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(UserFirstNameMaxLenght)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

        public Owner? Owner { get; set; }
    }
}
