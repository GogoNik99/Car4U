using Car4U.Core.Contracts;
using Car4U.Core.Models.Owner;
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

        public async Task CreateAsync(string userId, string phoneNumber, string Address)
        {
            await _repository.AddAsync(new Owner()
            {
                UserId = userId,
                PhoneNumber = phoneNumber,
                Address = Address,
                Rating = 0
            });

            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<OwnerRatingsViewModel>> GetAllOwnersRatingsAsync()
        {
            return await _repository.AllReadOnly<Owner>()
                .Select(o => new OwnerRatingsViewModel
                {
                    FullName = $"{o.User.FirstName} {o.User.LastName}",
                    Id = o.Id,
                    PhoneNumber = o.PhoneNumber,
                    Rating = o.Rating,
                    RatingsCount = o.Ratings.Count()
                })
                .ToListAsync();
        }

        public async Task<int> GetOwnerIdAsync(string userId)
        {
            var owner = await _repository.AllReadOnly<Owner>()
                .FirstAsync(o => o.UserId == userId);

            return owner.Id;
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
            => await _repository.AllReadOnly<Owner>().AnyAsync(o => o.UserId == userId);

        public async Task<bool> OwnerExistsByIdAsync(int id)
            => await _repository.AllReadOnly<Owner>().AnyAsync(o => o.Id == id);

        public async Task<bool> OwnerWithAddressExistsAsync(string Address)
            => await _repository.AllReadOnly<Owner>().AnyAsync(o => o.Address == Address);


        public async Task<bool> OwnerWithPhoneNumberExistsAsync(string phoneNumber)
            => await _repository.AllReadOnly<Owner>().AnyAsync(o => o.PhoneNumber == phoneNumber);
    }
}
