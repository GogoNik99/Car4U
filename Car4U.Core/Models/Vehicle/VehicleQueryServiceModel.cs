namespace Car4U.Core.Models.Car
{
    public class VehicleQueryServiceModel
    {
        public int TotalVehiclesCount { get; set; }

        public IEnumerable<VehicleServiceModel> Vehicles { get; set; } = new List<VehicleServiceModel>();
    }
}
