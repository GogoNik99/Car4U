using Car4U.Core.Enumerations;

namespace Car4U.Core.Models.Vehicle
{
    public class AllVehiclesQueryModel
    {
        public int VehiclesPerPage { get; set; } = 3;

        public string FuelType { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string SearchTerm { get; set; } = null!;

        public VehiclesSorting VehiclesSorting { get; set; }

        public int CurrentPage { get; init; } = 1;

        public int TotalVehiclesCount { get; set; }

        public IEnumerable<string> FuelTypes { get; set; } = null!;

        public IEnumerable<string> Models { get; set; } = null!;

        public IEnumerable<VehicleServiceModel> Vehicles { get; set; } = new List<VehicleServiceModel>();
    }
}
