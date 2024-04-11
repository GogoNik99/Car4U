namespace Car4U.Core.Contracts
{
    public interface IModelService
    {
        Task<bool> ModelExistsAsync(string name);

        Task CreateModelAsync(string name);

        Task<int> GetModelIdAsync(string name);
    }
}
