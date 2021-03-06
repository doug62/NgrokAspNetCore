﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NgrokAspNetCore.Sample.Models;

namespace NgrokAspNetCore.Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NgrokLocalApiClient _ngrokLocalApiClient;

        public HomeController(ILogger<HomeController> logger, NgrokLocalApiClient ngrokLocalApiClient )
        {
            _logger = logger;
            _ngrokLocalApiClient = ngrokLocalApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var tunnels = await _ngrokLocalApiClient.GetTunnelListAsync();
            return View(tunnels);
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
