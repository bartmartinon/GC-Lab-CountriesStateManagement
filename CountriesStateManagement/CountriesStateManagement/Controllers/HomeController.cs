using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CountriesStateManagement.Models;

namespace CountriesStateManagement.Controllers
{
    public class HomeController : Controller
    {
        List<Country> countryList = new List<Country>
        {
            new Country("USA",new List<string> { "English", "Spanish", "Chinese"}, "Hello World!" , "The United States of America: The Land of the Free and the Home of the Brave.", new List<string> { "Red", "White", "Blue" }),
            new Country("Spain", new List<string> { "Spanish", "Catalan" }, "Hola, Mundo!", "Spain: The Jewel of the Iberian Peninsula.", new List<string> { "Red", "Yellow" }),
            new Country("France", new List<string> { "French", "Occitan", "Alsatian" }, "Bonjour, Monde!", "France: A land of art, food, drama, love and bizzare cinema full of dark themes.", new List<string> { "Blue", "White", "Red" }),
            new Country("Japan", new List<string> { "Japanese" }, "Konichiwa, Warudo!", "Japan: The Sunrise Land, full of cherry blossoms.", new List<string> { "White", "Red" }),
            new Country("Canada", new List<string> { "English", "French" }, "Hello, World!", "Canada: The Crown of North America. Maple syrup, snow, trees, and more snow!", new List<string> { "Red", "White" })
        };

        public IActionResult Index()
        {
            return View(countryList);
        }

        [HttpPost]
        public IActionResult Index(string CountrySelect)
        {
            foreach (Country c in countryList)
            {
                if (c.Name.Equals(CountrySelect))
                {
                    TempData["name"] = c.Name;
                    TempData["languages"] = c.Languages;
                    TempData["helloworld"] = c.HelloWorld;
                    TempData["description"] = c.Description;
                    TempData["colors"] = c.Colors;
                }
            }                
            return RedirectToAction("Details");
        }

        public IActionResult Details()
        {
            ViewBag.name = TempData.Peek("name");
            ViewBag.languages = TempData.Peek("languages");
            ViewBag.helloworld = TempData.Peek("helloworld");
            ViewBag.description = TempData.Peek("description");
            ViewBag.colors = TempData.Peek("colors");

            return View();
        }

        [HttpPost]
        public IActionResult Details(string Description)
        {
            ViewBag.name = TempData.Peek("name");
            ViewBag.languages = TempData.Peek("languages");
            ViewBag.helloworld = TempData.Peek("helloworld");
            ViewBag.description = TempData.Peek("description");
            ViewBag.colors = TempData.Peek("colors");

            return RedirectToAction("DescriptionView");
        }

        public IActionResult DescriptionView()
        {
            ViewBag.name = TempData.Peek("name");
            ViewBag.languages = TempData.Peek("languages");
            ViewBag.helloworld = TempData.Peek("helloworld");
            ViewBag.description = TempData.Peek("description");
            ViewBag.colors = TempData.Peek("colors");

            return View();
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
