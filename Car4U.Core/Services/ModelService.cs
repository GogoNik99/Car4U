using Car4U.Core.Contracts;
using Car4U.Infrastructure.Data.Common;
using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Core.Services
{
    public class ModelService : IModelService
    {

        private readonly IRepository _repository;
        public ModelService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateModelAsync(string name)
        {
            var model = new Model()
            {
                Name = name
            };

            await _repository.AddAsync(model);
            await _repository.SaveChangesAsync();
        }

        public async Task<int> GetModelIdAsync(string name)
        {
            var model = await _repository.AllReadOnly<Model>()
                .FirstAsync(m => m.Name == name);

            return model.Id;
        }
        public async Task<bool> ModelExistsAsync(string name)
             => await _repository.AllReadOnly<Model>()
                .AnyAsync(m => m.Name == name);
    }
}
