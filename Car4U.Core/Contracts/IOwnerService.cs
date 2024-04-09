namespace Car4U.Core.Contracts
{
    public interface IOwnerService
    {
        Task<bool> IsOwnerAsync(int id, string userId);

        Task<bool> OwnerExistsAsync(string userId);
    }
}
