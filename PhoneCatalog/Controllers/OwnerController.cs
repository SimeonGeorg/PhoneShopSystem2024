using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Owner;
using PhoneCatalog.Infrastructure.Data.Common;
using System.Security.Claims;

namespace PhoneCatalog.Controllers
{
    public class OwnerController : BaseController
    {
        private readonly IRepository repository;
        private readonly IOwnerService ownerService;

        public OwnerController(
            IRepository _repository,
            IOwnerService _ownerService)
        {
            repository = _repository;
            ownerService = _ownerService;
        }

        [HttpGet]
        public IActionResult Become()
        {
            var ownerModel = new CreateOwnerModel();

            return View(ownerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Become(CreateOwnerModel ownerModel)
        {
            if (await ownerService.OwnerWithPhoneNumberExistsAsync(ownerModel.PhoneNumber))
            {
                ModelState.AddModelError(nameof(ownerModel.PhoneNumber), "Phone number exists");
            }

            if (ModelState.IsValid == false)
            {
                return View(ownerModel);
            }
            await ownerService.CreateAsync(User.Id(), ownerModel.PhoneNumber);


            return RedirectToAction(nameof(PhoneController.Add), "Phone");
        }
    }
}

