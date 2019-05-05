using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebsiteAleana.Models;

namespace WebsiteAleana.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Business()
        {
            return View();
        }

        public IActionResult Act()
        {
            return View();
        }

        public IActionResult RealEstate()
        {
            return View();
        }

        public IActionResult Auto()
        {
            return View();
        }

        public IActionResult Training()
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
