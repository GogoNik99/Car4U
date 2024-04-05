using Car4U.Core.Enumerations;
using Car4U.Core.Models.Car;

namespace Car4U.Core.Contracts
{
    public interface ICarService
    {
        Task<CarQueryServiceModel> AllAsync(
            string? FuelType = null,
            string? Model = null,
            string? SearchTerm = null,
            CarsSorting sorting = CarsSorting.Available,
            int currentPage = 1,
            int carsPerPage = 1);

        Task<IEnumerable<CarModelServiceModel>> AllModelsAsync();

        Task<IEnumerable<CarFuelTypeServiceModel>> AllFuelTypesAsync();

        Task<IEnumerable<string>> AllModelNamesAsync();
        Task<IEnumerable<string>> AllFuelTypeNamesAsync();
    }
}
