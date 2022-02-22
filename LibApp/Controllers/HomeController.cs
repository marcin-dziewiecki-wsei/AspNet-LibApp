﻿using LibApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace LibApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            DateTime currentTime;
            bool existsInCache = _memoryCache.TryGetValue("CachedTime", out currentTime);
            if (!existsInCache)
            {
                currentTime = DateTime.Now;
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(10),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(10)
                };

                _memoryCache.Set("CachedTime", currentTime, cacheEntryOptions);
            }

            return View(currentTime);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
