using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oop_dublin_bikes.Controllers
{
    public class BikesView : Controller
    {
        public string Index()
        {
            return "this is a test";
        }

        public IActionResult List(int limit)
        {
            if (limit == 0)
            {
                limit = 10;
            }
            ViewData["Limit"] = limit;
            return View("biking");
        }
    }
}
