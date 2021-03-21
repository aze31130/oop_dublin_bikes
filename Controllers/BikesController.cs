using Microsoft.AspNetCore.Mvc;
using oop_dublin_bikes.Data;

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
    }
}
