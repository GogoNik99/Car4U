using Car4U.Core.Models.Rating;

namespace Car4U.Core.Contracts
{
    public interface IRatingService
    {
        Task CreateRatingAsync(RatingFormViewModel model, int ownerId);
        Task<IEnumerable<RatingDetailsServiceModel>> GetRatingDetailsByOwnerIdAsync(int id);

        Task<decimal> SetOwnerRatingAsync(int id, decimal ratingValue);

    }
}
