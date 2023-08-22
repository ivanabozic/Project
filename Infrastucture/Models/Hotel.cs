using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Models
{
    public class Hotel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int NumberStar { get; set; }
        public Country Destination { get; set; }
        public int RoomNumber { get; set; }
    }
}
