namespace Car4U.Core.Contracts
{
    public interface IOwner
    {
        Task<bool> IsOwnerAsync(int id, string userId);
    }
}
