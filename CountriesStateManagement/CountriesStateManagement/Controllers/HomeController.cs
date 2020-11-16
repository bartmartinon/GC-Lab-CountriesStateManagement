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
            new Country("USA",new List<string> { "English", "Spanish", "Chinese"}, "Hello World!" , "The United States of America: The Land of the Free and the Home of the Brave.", new List<string> { "Red", "White", "Blue" }, "https://upload.wikimedia.org/wikipedia/en/thumb/a/a4/Flag_of_the_United_States.svg/125px-Flag_of_the_United_States.svg.png"),
            new Country("Spain", new List<string> { "Spanish", "Catalan" }, "Hola, Mundo!", "Spain: The Jewel of the Iberian Peninsula.", new List<string> { "Red", "Yellow" }, "https://upload.wikimedia.org/wikipedia/en/thumb/9/9a/Flag_of_Spain.svg/125px-Flag_of_Spain.svg.png"),
            new Country("France", new List<string> { "French", "Occitan", "Alsatian" }, "Bonjour, Monde!", "France: A land of art, food, drama, love and bizzare cinema full of dark themes.", new List<string> { "Blue", "White", "Red" }, "https://upload.wikimedia.org/wikipedia/en/thumb/c/c3/Flag_of_France.svg/125px-Flag_of_France.svg.png"),
            new Country("Japan", new List<string> { "Japanese" }, "Konichiwa, Warudo!", "Japan: The Sunrise Land, full of cherry blossoms.", new List<string> { "White", "Red" }, "https://upload.wikimedia.org/wikipedia/en/thumb/9/9e/Flag_of_Japan.svg/125px-Flag_of_Japan.svg.png"),
            new Country("Canada", new List<string> { "English", "French" }, "Hello, World!", "Canada: The Crown of North America. Maple syrup, snow, trees, and more snow!", new List<string> { "Red", "White" }, "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Flag_of_Canada_%28Pantone%29.svg/125px-Flag_of_Canada_%28Pantone%29.svg.png")
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
                    TempData["piclink"] = c.PicLink;
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
            ViewBag.piclink = TempData.Peek("piclink");

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
            ViewBag.piclink = TempData.Peek("piclink");

            return RedirectToAction("DescriptionView");
        }

        public IActionResult DescriptionView()
        {
            ViewBag.name = TempData.Peek("name");
            ViewBag.languages = TempData.Peek("languages");
            ViewBag.helloworld = TempData.Peek("helloworld");
            ViewBag.description = TempData.Peek("description");
            ViewBag.colors = TempData.Peek("colors");
            ViewBag.piclink = TempData.Peek("piclink");

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
