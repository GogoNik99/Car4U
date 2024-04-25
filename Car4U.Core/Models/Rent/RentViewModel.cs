namespace Car4U.Core.Models.Rent
{
    public class RentViewModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = string.Empty;

        public string OwnerName { get; set; } = string.Empty;

        public string OwnerEmail { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string RenterName { get; set; } = string.Empty;
    }
}
