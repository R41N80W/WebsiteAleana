using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebsiteAleana.Models;

namespace WebsiteAleana.Controllers
{
    public class MiscController : Controller
    {
        public IActionResult Reorganization()
        {
            return View();
        }

        public IActionResult Training()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Articles()
        {
            return View();
        }

        public IActionResult SpecialOffers()
        {
            return View();
        }

        public IActionResult Tech()
        {
            return View();
        }

        public IActionResult UnauthBuild()
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