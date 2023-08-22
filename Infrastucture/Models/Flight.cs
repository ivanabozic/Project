using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Models
{
    public class Flight
    {
        public string Id { get; set; }
        public Country Origin { get; set; }
        public Country Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Return { get; set; }
        public float Price { get; set; }

    }
}
