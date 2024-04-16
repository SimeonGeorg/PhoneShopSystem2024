using Microsoft.AspNetCore.Mvc;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Owner;
using PhoneCatalog.Core.Models.Phone;
using PhoneCatalog.Core.Services;
using PhoneCatalog.Infrastructure.Data.Models;
using System.Security.Claims;

namespace PhoneCatalog.Controllers
{
    public class PhoneController : BaseController
    {
        private readonly ILogger<PhoneController> _logger;
        private readonly IPhoneService phoneService;
        private readonly IOwnerService ownerService;
        private readonly IPerformanceService performanceService;


        public PhoneController(
            ILogger<PhoneController> logger,
            IPhoneService _phoneService,
            IOwnerService _ownerService,
            IPerformanceService _performanceService)
        {
            _logger = logger;
            phoneService = _phoneService;
            ownerService = _ownerService;
            performanceService = _performanceService;

        }

        public async Task<IActionResult> All()
        {
            var model = await phoneService.AllPhonesAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<PhoneServiceModel> model;



            if (await ownerService.IsExistByIdAsync(userId))
            {
                int ownerId = await ownerService.GetOwnerIdAsync(userId) ?? 0;
                model = await phoneService.AllPhonesByOwnerIdAsync(ownerId);
                return View(model);
            }
            else
            {
                model = await phoneService.AllPhonesByUserIdAsync(userId);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await phoneService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await phoneService.PhoneDetailsByIdAsync(id);
            model.Performances = await phoneService.PerformanceDetailsByPhoneIdAsync(model.Id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var modelPhone = new PhoneAddModel()
            {
                Categories = await phoneService.AllCategoriesAsync()
            };
            return View(modelPhone);
        }
        [HttpPost]
        public async Task<IActionResult> Add(PhoneAddModel modelPhone)
        {
            if (await phoneService.CategoryExistsAsync(modelPhone.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(modelPhone.CategoryId), "Category does not exist");
            }
            if (ModelState.IsValid == false)
            {
                modelPhone.Categories = await phoneService.AllCategoriesAsync();

                return View(modelPhone);
            }

            int? ownerId = await ownerService.GetOwnerIdAsync(User.Id());

            int newPhoneId = await phoneService.CreateAsync(modelPhone, ownerId ?? 0);

            int performance = await performanceService.CreateAsync(modelPhone, newPhoneId);


            return RedirectToAction(nameof(Details), new { id = newPhoneId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await phoneService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await phoneService.HasOwnerWithId(id, User.Id()) == false)
            //&& User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var phoneModel = await phoneService.GetPhoneEditFormByIdAsync(id);
            phoneModel.Performances = await performanceService.GetPerformancesByPhoneId(id);

            return View(phoneModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PhoneEditFormModel phoneModel)
        {
            if (await phoneService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await phoneService.HasOwnerWithId(id, User.Id()) == false)
                //&& User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await phoneService.CategoryExistsAsync(phoneModel.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(phoneModel.CategoryId), "Category does not exist");
            }

            if (ModelState.IsValid == false)
            {
                phoneModel.Categories = await phoneService.AllCategoriesAsync();

                return View(phoneModel);
            }

            await phoneService.EditAsync(id, phoneModel);
           

            return RedirectToAction(nameof(Details), new { id});

        }
    } }
