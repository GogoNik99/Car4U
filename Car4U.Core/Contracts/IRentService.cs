using Car4U.Core.Models.Rent;

namespace Car4U.Core.Contracts
{
    public interface IRentService
    {
        Task<IEnumerable<RentViewModel>> GetAllRentsAsync();
    }
}
