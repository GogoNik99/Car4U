﻿using Car4U.Core.Enumerations;
using Car4U.Core.Models.Vehicle;
using Car4U.Infrastructure.Data.Models;

namespace Car4U.Core.Contracts
{
    public interface IVehicleService
    {
        Task<VehicleQueryServiceModel> AllAsync(
            string? fuelType = null,
            string? model = null,
            string? searchTerm = null,
            VehiclesSorting sorting = VehiclesSorting.Available,
            int currentPage = 1,
            int vehiclesPerPage = 1);

        Task<IEnumerable<VehicleModelServiceModel>> AllModelsAsync();

        Task<IEnumerable<VehicleFuelTypeServiceModel>> AllFuelTypesAsync();

        Task<IEnumerable<string>> AllModelNamesAsync();
        Task<IEnumerable<string>> AllFuelTypeNamesAsync();

        Task<VehicleDetailsViewModel> GetVehiclesDetailsAsync(int id);

        Task<bool> FuelTypeExists(int id);
        Task<bool> ExistsAsync(int id);

        Task<bool> HasOwnerWithIdAsync(int id, string userId);

        Task<bool> IsRentedByIUserWithIdAsync(int id, string userId);

        Task<IEnumerable<VehicleServiceModel>> AllVehiclesByOwner(string userId);

        Task<IEnumerable<VehicleServiceModel>> AllVehiclesByRenter(string userId);
        Task CreateAsync(VehicleFormModel model, int ownerId);

        Task<VehicleFormModel?> GetVehicleFormById(int id);
        Task EditAsync(int id, VehicleFormModel model);
        Task RentAsync(int id, string userId);
        Task<bool> IsRentedAsync(int id);
        Task ReturnAsync(int id);
        Task DeleteVehicleAsync(int id);

        Task<VehicleDeleteDetailsViewModel?> GetDeleteDetailsAsync(int id);
        Task<IEnumerable<VehicleServiceModel>> GetUnApprovedAsync();
        Task ApproveVehicleAsync(int id);

        Task<bool> IsVehicleApproved(int id);

        Task<Vehicle> GetVehicleByIdAsync(int id);

        Task<Vehicle?> GetRentedVehicleByUserId(string userId);
    }
}
