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
    public class BikesController : ControllerBase
    {
        private readonly Context _context;
        public BikesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bike>>> GetBikes()
        {
            return await _context.Bikes.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Bike>> Add_Bike(Bike Bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bike = new Bike()
            {
                _id = Bike._id,
                Number = Bike.Number,
                Name = Bike.Name,
                Address = Bike.Address,
                Latitude = Bike.Latitude,
                Longitude = Bike.Longitude
            };
            _context.Bikes.Add(Bike);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetBike", new { id = Bike._id }, Bike);

        }

        [HttpPut("id")]
        public async Task<ActionResult> UpdateBike(int id, Bike bike)
        {
            if (!id.Equals(bike._id) || !_context.Bikes.Any(x => x._id.Equals(id)))
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(bike).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBikes", new { id = bike._id }, bike);
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Bike>> DeleteBike(int id)
        {
            var bike = await _context.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }
            else
            {
                _context.Bikes.Remove(bike);
                await _context.SaveChangesAsync();
                return bike;
            }
        }
    }
}
