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
        private readonly ICommentService commentService;
        private readonly IPhoneService phoneService;

        public OwnerController(
            IRepository _repository,
            IOwnerService _ownerService,
            ICommentService _commentService,
            IPhoneService _phoneService)
        {
            repository = _repository;
            ownerService = _ownerService;
            commentService = _commentService;
            phoneService = _phoneService;
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
        [HttpGet]
        public async Task<IActionResult> Personal()
        {
            var userId = User.Id();
            OwnerPersonalModel model;
           
            if (await ownerService.IsExistByIdAsync(userId))
            {
                int ownerId = await ownerService.GetOwnerIdAsync(userId) ?? 0;
                model = await ownerService.GetOwnerPersonalInfo(ownerId);
                model.Comments = await commentService.AllCommentByOwnerId(ownerId);
                model.Phones = await phoneService.AllPhonesByOwnerIdAsync(ownerId);

                return View(model);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

