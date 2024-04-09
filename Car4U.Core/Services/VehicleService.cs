using Car4U.Core.Contracts;
using Car4U.Core.Enumerations;
using Car4U.Core.Extensions;
using Car4U.Core.Models.Vehicle;
using Car4U.Infrastructure.Data.Common;
using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository _repository;
        private IOwnerService _owner;
        public VehicleService(IRepository repository, IOwnerService owner)
        {
            _repository = repository;
            _owner = owner;
        }

        public async Task<VehicleQueryServiceModel> AllAsync(string? fuelType = null, string? model = null, string? searchTerm = null, VehiclesSorting sorting = VehiclesSorting.Available, int currentPage = 1, int vehiclesPerPage = 1)
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
                vehiclesToShow = vehiclesToShow.Where(v => v.FuelType.Name == fuelType);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                vehiclesToShow = vehiclesToShow
                    .Where(v => v.Manufacturer.ToLower().Contains(normalizedSearchTerm) ||
                           v.Description.ToLower().Contains(normalizedSearchTerm) ||
                           v.Model.Name.ToLower().Contains(normalizedSearchTerm));
            }

            vehiclesToShow = sorting switch
            {
                VehiclesSorting.HighestPrice =>
                vehiclesToShow.OrderByDescending(v => v.Price),

                VehiclesSorting.LowestPrice =>
                vehiclesToShow.OrderBy(v => v.Price),

                VehiclesSorting.OwnerRating =>
                vehiclesToShow.OrderByDescending(v => v.Owner.Rating),

                VehiclesSorting.Available =>
                vehiclesToShow.OrderBy(v => v.RenterId != null)
                .ThenBy(v => v.Id),

                _ => vehiclesToShow.OrderBy(v => v.Id)
            };

            var vehicles = await vehiclesToShow
                .Skip((currentPage - 1) * vehiclesPerPage)
                .Take(vehiclesPerPage)
                .ProjectToVehicleServiceModel()
                .ToListAsync();

            var totalVehicles = await vehiclesToShow.CountAsync();

            return new VehicleQueryServiceModel()
            {
                Vehicles = vehicles,
                TotalVehiclesCount = totalVehicles
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

        public async Task<IEnumerable<VehicleServiceModel>> AllVehiclesByOwner(string userId)
        {
            return await _repository.AllReadOnly<Vehicle>()
                    .Where(v => v.Owner.UserId == userId)
                    .Select(v => new VehicleServiceModel()
                    {
                        Id = v.Id,
                        Description = v.Description,
                        Fuel = v.FuelType.Name,
                        ImageFileName = v.ImageFileName,
                        IsRented = v.RenterId != null,
                        Manifacturer = v.Manufacturer,
                        Name = v.Model.Name,
                        Price = v.Price,
                        Rating = v.Owner.Rating
                    })
                    .ToListAsync();
        }

        public async Task<IEnumerable<VehicleServiceModel>> AllVehiclesByRenter(string userId)
        {
            return await _repository.AllReadOnly<Vehicle>()
                    .Where(v => v.RenterId == userId)
                    .Select(v => new VehicleServiceModel()
                    {
                        Id = v.Id,
                        Description = v.Description,
                        Fuel = v.FuelType.Name,
                        ImageFileName = v.ImageFileName,
                        IsRented = v.RenterId != null,
                        Manifacturer = v.Manufacturer,
                        Name = v.Model.Name,
                        Price = v.Price,
                        Rating = v.Owner.Rating
                    })
                    .ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
            => await _repository.AllReadOnly<Vehicle>()
                .AnyAsync(v => v.Id == id);

        public async Task<VehicleDetailsViewModel> GetVehiclesDetailsAsync(int id)
        {

            return await _repository.AllReadOnly<Vehicle>()
                .Where(v => v.Id == id)
                .Where(v => v.IsActive == true)
                .Select(v => new VehicleDetailsViewModel()
                {
                    Id = v.Id,
                    Description = v.Description,
                    Fuel = v.FuelType.Name,
                    ImageFileName = v.ImageFileName,
                    IsRented = v.RenterId != null,
                    Manifacturer = v.Manufacturer,
                    Name = v.Model.Name,
                    Price = v.Price,
                    Rating = v.Owner.Rating,
                    Owner = new Models.Owner.OwnerServiceModel()
                    {
                        Address = v.Owner.Address,
                        Email = v.Owner.User.Email,
                        PhoneNumber = v.Owner.PhoneNumber
                    }
                }).FirstAsync();
        }

        public async Task<bool> HasOwnerWithIdAsync(int id, string userId)
            => await _repository.AllReadOnly<Vehicle>()
                .AnyAsync(v => v.Id == id && v.Owner.UserId == userId);

        public async Task<bool> IsRentedByIUserWithIdAsync(int id, string userId)
            => await _repository.AllReadOnly<Vehicle>()
                .AnyAsync(v => v.Id == id && v.RenterId == userId);


    }
}
