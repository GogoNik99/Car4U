using Car4U.Core.Contracts;
using Car4U.Infrastructure.Data.Common;
using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository _repository;
        public OwnerService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsOwnerAsync(int id, string userId)
        {
            var vehicle = await _repository.AllReadOnly<Vehicle>()
                .FirstOrDefaultAsync(v => v.Id == id && v.Owner.UserId == userId);

            if (vehicle == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> OwnerExistsAsync(string userId)
        {
            var owner = await _repository.AllReadOnly<Owner>()
                .FirstOrDefaultAsync(o => o.UserId == userId);

            if (owner == null)
            {
                return false;
            }

            return true;
        }
    }
}
