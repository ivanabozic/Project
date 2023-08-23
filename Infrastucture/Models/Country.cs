using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Capital { get; set; }
        public virtual ICollection<Town>? Towns { get; set; }
    }
}
