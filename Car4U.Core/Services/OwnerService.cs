using Car4U.Core.Contracts;
using Car4U.Infrastructure.Data.Common;
using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Core.Services
{
    public class OwnerService : IOwner
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

    }
}
