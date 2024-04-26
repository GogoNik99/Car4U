using Car4U.Core.Models.Owner;

namespace Car4U.Core.Contracts
{
    public interface IOwnerService
    {
        Task<bool> IsOwnerAsync(int id, string userId);

        Task<bool> OwnerExistsAsync(string userId);

        Task<bool> OwnerExistsByIdAsync(int id);

        Task<bool> OwnerWithPhoneNumberExistsAsync(string phoneNumber);

        Task<bool> OwnerWithAddressExistsAsync(string Address);

        Task CreateAsync(string userId, string phoneNumber, string Address);

        Task<int> GetOwnerIdAsync(string userId);

        Task<IEnumerable<OwnerRatingsViewModel>> GetAllOwnersRatingsAsync();




    }
}
