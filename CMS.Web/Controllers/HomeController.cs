using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserType = "Administrator";
            //ViewBag.fullName = "Sadeg Ashour";
            TempData["fullName"] = "Sadeg Ashour";
            
            return View();
        }
    
    }
}