using Microsoft.EntityFrameworkCore;
using oop_dublin_bikes.Models;

namespace oop_dublin_bikes.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Bike> Bikes { get; set; }
    }
}
