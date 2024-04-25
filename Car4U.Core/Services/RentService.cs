using Car4U.Core.Contracts;
using Car4U.Core.Models.Rent;
using Car4U.Infrastructure.Data.Common;
using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Core.Services
{
    public class RentService : IRentService
    {
        private readonly IRepository _repository;

        public RentService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<RentViewModel>> GetAllRentsAsync()
        {
            return await _repository.AllReadOnly<Vehicle>()
                .Where(v => v.RenterId != null)
                .Include(v => v.Owner)
                .Include(v => v.Model)
                .Include(v => v.Renter)
                .Select(v => new RentViewModel
                {
                    Id = v.Id,
                    ModelName = v.Model.Name,
                    OwnerEmail = v.Owner.User.Email,
                    OwnerName = $"{v.Owner.User.FirstName} {v.Owner.User.LastName}",
                    PhoneNumber = v.Owner.PhoneNumber,
                    RenterName = $"{v.Renter.FirstName} {v.Renter.LastName}"

                })
                .ToListAsync();
        }
    }
}
