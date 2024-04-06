using Car4U.Core.Models.Vehicle;
using Car4U.Infrastructure.Data.Models;

namespace Car4U.Core.Extensions
{
    public static class IQueryableExtension
    {

        public static IQueryable<VehicleServiceModel> ProjectToVehicleServiceModel(this IQueryable<Vehicle> vehicles)
        {
            return vehicles
                .Select(v => new VehicleServiceModel
                {
                    Id = v.Id,
                    Description = v.Description,
                    ImageFileName = v.ImageFileName,
                    IsRented = v.RenterId != null,
                    Manifacturer = v.Manufacturer,
                    Price = v.Price,
                    Rating = v.Owner.Rating,
                    Name = v.Model.Name
                });
        }
    }
}
