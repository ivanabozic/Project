using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Models
{
    public class Recommendation
    {
        public string? Id { get; set; }
        public Guid? TownId { get; set; }
        public float Price { get; set; }
        public DateTime Departure { get; set; }
        public virtual Town? Town { get; set; }

    }
}
