using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oop_dublin_bikes.Data;
using oop_dublin_bikes.Models;
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

        //Main View
        public IActionResult Index()
        {
            BikeViewModel model = new BikeViewModel();
            model.Bikes = _context.bikes.ToList();
            return View(model);
        }

        //Create View
        public IActionResult Create()
        {
            return View();
        }

        //Post method to create the bike
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(
            "id,Number,Name,Address,Latitude,Longitude,ContractName,Banking,AvailableBikes,AvailableStands,Capacity,Status")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        //Edit View
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bike = _context.bikes.Find(id);
            if (bike == null)
            {
                return NotFound();
            }
            ViewData["Id"] = id;
            return View(bike);
        }

        //Post method to edit a bike
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(
            "id,Number,Name,Address,Latitude,Longitude,ContractName,Banking,AvailableBikes,AvailableStands,Capacity,Status")] Bike bike)
        {
            if (!id.Equals(bike.id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!isBikeExist(bike.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        //Detail View
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var bike = _context.bikes.FirstOrDefault(x => x.id.Equals(id));
            if (bike == null)
            {
                return NotFound();
            }
            return View(bike);
        }

        //Delete View
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bike = _context.bikes.FirstOrDefault(x => x.id.Equals(id));
            if (bike == null)
            {
                return NotFound();
            }
            return View(bike);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMethod(int id)
        {
            var bike = await _context.bikes.FindAsync(id);
            _context.bikes.Remove(bike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool isBikeExist(int id)
        {
            return _context.bikes.Any(x => x.id.Equals(id));
        }
    }
}
