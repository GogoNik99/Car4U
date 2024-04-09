using Car4U.Core.Models.Owner;

namespace Car4U.Core.Models.Vehicle
{
    public class VehicleDetailsViewModel : VehicleServiceModel
    {
        public OwnerServiceModel Owner { get; set; } = null!;
    }
}
