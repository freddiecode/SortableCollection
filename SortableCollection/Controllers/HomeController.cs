using Microsoft.AspNetCore.Mvc;
using SortableCollection.Models;
using System.Diagnostics;

namespace SortableCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string sortOrder)
        {
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CitySortParm"] = String.IsNullOrEmpty(sortOrder) ? "city_desc" : "";
            ViewData["StateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "state_desc" : "";
            ViewData["PhoneSortParm"] = String.IsNullOrEmpty(sortOrder) ? "phone_desc" : "";


            var contacts = new[]
            {
        new Contact{Id = 1, Name="dave", City="Seattle", State="WA", Phone="123"},
        new Contact{Id = 2, Name="mike", City="Spokane", State="WA", Phone="234"},
        new Contact{Id = 3, Name="lisa", City="San Jose", State="CA", Phone="345"},
        new Contact{Id = 4, Name="cathy", City="Dallas", State="TX", Phone="456"},
            };

            var allcontacts = from c in contacts select c;

            if (sortOrder != null)
            {
                switch (sortOrder.ToLower())
                {
                    case "id_desc":

                        allcontacts = allcontacts.OrderByDescending(c => c.Id);
                        break;

                    case "name_desc":

                        allcontacts = allcontacts.OrderByDescending(c => c.Name);
                        break;

                    case "city_desc":
                        allcontacts = allcontacts.OrderByDescending(c => c.City);
                        break;

                    case "state_desc":

                        allcontacts = allcontacts.OrderByDescending(c => c.State);
                        break;

                    case "phone_desc":

                        allcontacts = allcontacts.OrderByDescending(c => c.Phone);
                        break;

                    default:
                        allcontacts = allcontacts.OrderBy(c => c.Id);
                        break;
                }
            }

            return View(allcontacts);
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