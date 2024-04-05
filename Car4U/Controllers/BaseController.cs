using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Car4U.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
