using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAPI.Models
{
    public class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
