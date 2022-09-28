using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Northwind.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Web.Repository;

namespace Northwind.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var myName = "Iwan";
            return View("Index", myName);
        }



        public IActionResult Privacy()
        {
            var hour = DateTime.Now.Hour;
            //Tennary Operation (If/Else)
            var waktu = hour > 12 ? "Good Day" : "Good Mornig";
            return View("privacy",waktu);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
