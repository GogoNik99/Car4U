using Car4U.Core.Contracts;
using Car4U.Core.Enumerations;
using Car4U.Core.Models.Car;
using Car4U.Infrastructure.Data.Common;
using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository _repository;

        public VehicleService(IRepository repository)
        {
            _repository = repository;
        }

        public Task<VehicleQueryServiceModel> AllAsync(string? fuelType = null, string? model = null, string? searchTerm = null, VehiclesSorting sorting = VehiclesSorting.Available, int currentPage = 1, int carsPerPage = 1)
        {
            var vehiclesToShow = _repository
                .AllReadOnly<Vehicle>()
                .Where(v => v.IsActive == true);

            if (model != null)
            {
                vehiclesToShow = vehiclesToShow.Where(v => v.Model.Name == model);
            }

            if (fuelType != null)
            {
                vehiclesToShow = vehiclesToShow.Where(v => v.FuelType.Name == model);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                vehiclesToShow = vehiclesToShow
                    .Where(v => v.Manufacturer.ToLower().Contains(normalizedSearchTerm) ||
                           v.Description.ToLower().Contains(normalizedSearchTerm));
            }

            vehiclesToShow = sorting switch
            {
                VehiclesSorting.HighestPrice =>
            };


        }

        public async Task<IEnumerable<string>> AllFuelTypeNamesAsync()
        {
            return await _repository.AllReadOnly<FuelType>()
               .Select(c => c.Name)
               .ToListAsync();
        }

        public async Task<IEnumerable<VehicleFuelTypeServiceModel>> AllFuelTypesAsync()
        {
            return await _repository.AllReadOnly<FuelType>()
                .Select(c => new VehicleFuelTypeServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

        }

        public async Task<IEnumerable<string>> AllModelNamesAsync()
        {
            return await _repository.AllReadOnly<Model>()
               .Select(c => c.Name)
               .Distinct()
               .ToListAsync();
        }

        public async Task<IEnumerable<VehicleModelServiceModel>> AllModelsAsync()
        {
            return await _repository.AllReadOnly<Model>()
                .Select(c => new VehicleModelServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }
    }
}
