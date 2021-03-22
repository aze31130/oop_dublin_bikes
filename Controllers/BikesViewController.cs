using Microsoft.AspNetCore.Mvc;
using oop_dublin_bikes.Data;
using oop_dublin_bikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oop_dublin_bikes.Controllers
{
    public class BikesViewController : Controller
    {
        private readonly Context _context;

        public BikesViewController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            BikeViewModel model = new BikeViewModel();
            model.Bikes = _context.bikes.ToList();

            ViewData["View"] = _context.bikes.ToList();
            return View(model);
        }

        public IActionResult List(int limit)
        {
            if (limit == 0)
            {
                limit = 10;
            }
            ViewData["Limit"] = limit;
            BikeViewModel model = new BikeViewModel();
            model.Bikes = _context.bikes.ToList();

            ViewData["View"] = _context.bikes.ToList();
            return View("biking");
        }
    }
}
