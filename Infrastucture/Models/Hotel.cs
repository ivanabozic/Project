using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int NumberStar { get; set; }
        public int RoomNumber { get; set; }
        public Guid? TownId { get; set; }
        public virtual Town? Town { get; set; }
    }
}
