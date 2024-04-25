using Car4U.Core.Contracts;
using Car4U.Core.Models.Admin.User;
using Car4U.Infrastructure.Data.Common;
using Car4U.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserInfoViewModel>> AllUsersAsync()
        {
            return await _repository.AllReadOnly<ApplicationUser>()
                .Include(u => u.Owner)
                .Select(u => new UserInfoViewModel
                {
                    Email = u.Email,
                    IsOwner = u.Owner != null,
                    UserFullName = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();


        }
    }
}
