using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Car4U.Core.Constants.RoleConstants;

namespace Car4U.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
