using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oop_dublin_bikes.Data;
using oop_dublin_bikes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oop_dublin_bikes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BikesController : Controller
    {
        private readonly Context _context;
        public BikesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bike>>> GetBikes()
        {
            return await _context.bikes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Bike>> Add_Bike(Bike Bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.bikes.Add(Bike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBikes", new { id = Bike.id }, Bike);

        }

        [HttpPut("id")]
        public async Task<ActionResult> UpdateBike(int id, Bike bike)
        {
            if (!id.Equals(bike.id) || !_context.bikes.Any(x => x.id.Equals(id)))
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(bike).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBikes", new { id = bike.id }, bike);
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Bike>> DeleteBike(int id)
        {
            var bike = await _context.bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }
            else
            {
                _context.bikes.Remove(bike);
                await _context.SaveChangesAsync();
                return bike;
            }
        }
    }
}
