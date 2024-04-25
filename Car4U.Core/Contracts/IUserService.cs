using Car4U.Core.Models.Admin.User;

namespace Car4U.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserInfoViewModel>> AllUsersAsync();
    }
}
