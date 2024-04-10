using Microsoft.AspNetCore.Mvc;
using PhoneCatalog.Core.Contracts;

namespace PhoneCatalog.Controllers
{
    public class PhoneController : BaseController
    {
        private readonly ILogger<PhoneController> _logger;
        private readonly IPhoneService phoneService;

        public PhoneController(
            ILogger<PhoneController> logger,
            IPhoneService _phoneService)
        {
            _logger = logger;
            phoneService = _phoneService;
        }

        public async Task<IActionResult> AllAsync()
        {
            var model = await phoneService.AllPhonesAsync();
            return View(model);
        }
    }
}
