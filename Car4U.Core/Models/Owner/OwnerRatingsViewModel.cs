namespace Car4U.Core.Models.Owner
{
    public class OwnerRatingsViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public decimal Rating { get; set; }

        public int RatingsCount { get; set; }


    }
}
