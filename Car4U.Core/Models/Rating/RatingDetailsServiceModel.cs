namespace Car4U.Core.Models.Rating
{
    public class RatingDetailsServiceModel
    {
        public int Id { get; set; }

        public string OwnerName { get; set; }

        public string? Description { get; set; }

        public decimal RatingValue { get; set; }

    }
}
