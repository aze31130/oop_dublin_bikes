using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace oop_dublin_bikes.Models
{
    public class Bike
    {
        [Key]
        [RegularExpression(@"[0-9]*")]
        public int _id { get; set; }
        [RegularExpression(@"[0-9]*")]
        public int Number { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Address { get; set; }
        [RegularExpression(@"[0-9]+.[0-9]*")]
        [Range(-90, 90)]
        public double Latitude { get; set; }
        [RegularExpression(@"[0-9]+.[0-9]*")]
        [Range(-180, 180)]
        public double Longitude { get; set; }
    }
}
