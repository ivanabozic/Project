using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Models
{
    public class Reservation
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Country? Destination { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set;}
        public float Price { get; set; }
    }
}
