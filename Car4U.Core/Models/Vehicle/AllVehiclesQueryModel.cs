using Car4U.Core.Enumerations;
using Car4U.Infrastructure.Data.Models;

namespace Car4U.Core.Models.Car
{
    public class AllVehiclesQueryModel
    {
        public int VehiclesPerPage { get; set; } = 3;

        public string FuelType { get; set; } = null!;

        public string SearchTerm { get; set; } = null!;

        public VehiclesSorting CarsSorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalCarsCount { get; set; }

        public IEnumerable<FuelType> FuelTypes { get; set; } = null!;

        public IEnumerable<Model> Models { get; set; } = null!;

        public IEnumerable<VehicleQueryServiceModel> Cars { get; set; } = new List<VehicleQueryServiceModel>();
    }
}
