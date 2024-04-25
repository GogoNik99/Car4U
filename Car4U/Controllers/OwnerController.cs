using Car4U.Attributes;
using Car4U.Core.Contracts;
using Car4U.Core.Models.Owner;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Car4U.Controllers
{
    public class OwnerController : BaseController
    {
        private readonly IOwnerService _ownerService;

        private readonly ILogger _logger;

        public OwnerController
            (IOwnerService ownerSerive,
            ILogger<OwnerController> logger
            )
        {
            _ownerService = ownerSerive;
            _logger = logger;
        }

        [HttpGet]
        [NotAnOwner]
        public IActionResult Become()
        {

            var model = new OwnerFormModel();

            return View(model);
        }

        [HttpPost]
        [NotAnOwner]
        public async Task<IActionResult> Become(OwnerFormModel model)
        {
            if (await _ownerService.OwnerWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "This phonenumber exists");
            }

            if (await _ownerService.OwnerWithAddressExistsAsync(model.Address))
            {
                ModelState.AddModelError(nameof(model.Address), "This address already exists");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _ownerService.CreateAsync(User.Id(), model.PhoneNumber, model.Address);
            return RedirectToAction(nameof(HomeController), "Index");
        }


    }
}
