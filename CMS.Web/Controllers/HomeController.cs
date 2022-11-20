﻿using CMS.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IDashboardService _dashboardService;

        public HomeController(IDashboardService dashboardService) { 
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _dashboardService.GetData();
            
            return View(data);
        }

        public async Task<IActionResult> GetUserTypeChartData()
        {
            var data = await _dashboardService.GetUserTypeChart();

            return Ok(data);
        }
        public async Task<IActionResult> GetContentTypeChartData()
        {
            var data = await _dashboardService.GetContentTypeChart();

            return Ok(data);
        }
        public async Task<IActionResult> GetContentByMonthChartData()
        {
            var data = await _dashboardService.GetContentByMonthChart();

            return Ok(data);
        }
    }
}