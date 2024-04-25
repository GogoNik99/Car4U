namespace Car4U.Core.Models.Admin.User
{
    public class UserInfoViewModel
    {
        public string UserFullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsOwner { get; set; }

        public int VehicleCount { get; set; }


    }
}
