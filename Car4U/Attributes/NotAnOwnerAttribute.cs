using Car4U.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Car4U.Attributes
{
    public class NotAnOwnerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IOwnerService? ownerService = context.HttpContext.RequestServices.GetService<IOwnerService>();

            if (ownerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (ownerService != null
                && ownerService.OwnerExistsAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
