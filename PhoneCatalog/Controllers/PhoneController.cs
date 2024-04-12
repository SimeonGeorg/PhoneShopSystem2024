using Microsoft.AspNetCore.Mvc;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Phone;
using PhoneCatalog.Core.Services;
using System.Security.Claims;

namespace PhoneCatalog.Controllers
{
    public class PhoneController : BaseController
    {
        private readonly ILogger<PhoneController> _logger;
        private readonly IPhoneService phoneService;
        private readonly IOwnerService ownerService;
      

        public PhoneController(
            ILogger<PhoneController> logger,
            IPhoneService _phoneService,
            IOwnerService _ownerService)
        {
            _logger = logger;
            phoneService = _phoneService;
            ownerService = _ownerService;
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

    }
}
