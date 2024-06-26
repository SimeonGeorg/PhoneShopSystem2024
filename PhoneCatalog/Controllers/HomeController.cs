﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Models;
using System.Diagnostics;

namespace PhoneCatalog.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPhoneService phoneService;

        public HomeController(
            ILogger<HomeController> logger,
            IPhoneService _phoneService
            )
        {
            _logger = logger;
            phoneService = _phoneService;
        }
        [AllowAnonymous]
        public  IActionResult Index()
        {
            if (!User?.Identity?.IsAuthenticated ?? true)
            {
                return View();
            }
            return RedirectToAction("All","Phone");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}