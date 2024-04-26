using Car4U.Core.Contracts;
using Car4U.Core.Models.Rating;
using Car4U.Infrastructure.Data.Common;
using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Core.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRepository _repository;
        private readonly IOwnerService _ownerService;
        public RatingService(IRepository repository, IOwnerService ownerService)
        {
            _repository = repository;
            _ownerService = ownerService;
        }

        public async Task CreateRatingAsync(RatingFormViewModel model, int ownerId)
        {
            Rating rating = new Rating
            {
                Description = model.Description,
                OwnerId = ownerId,
                RatingValue = model.RatingValue,
            };

            Owner owner = await _repository.GetByIdAsync<Owner>(ownerId);

            if (owner != null)
            {
                owner.Rating = await SetOwnerRatingAsync(owner.Id, model.RatingValue);
            }

            await _repository.AddAsync(rating);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<RatingDetailsServiceModel>> GetRatingDetailsByOwnerIdAsync(int id)
        {
            return await _repository.AllReadOnly<Rating>()
                    .Where(r => r.OwnerId == id)
                    .Select(r => new RatingDetailsServiceModel
                    {
                        Description = r.Description,
                        Id = r.Id,
                        RatingValue = r.RatingValue,
                        OwnerName = $"{r.Owner.User.FirstName} {r.Owner.User.LastName}"
                    })
                    .ToListAsync();

        }

        public async Task<decimal> SetOwnerRatingAsync(int id, decimal ratingValue)
        {
            var owner = await _repository.GetByIdAsync<Owner>(id);

            List<Rating> ratings = await _repository.AllReadOnly<Rating>()
                    .Where(r => r.OwnerId == id)
                    .ToListAsync();

            decimal rating = 0;
            if (owner != null && ratings != null)
            {
                rating = (ratings.Sum(r => r.RatingValue) + ratingValue) / (ratings.Count() + 1);
            }

            return rating;
        }
    }
}
