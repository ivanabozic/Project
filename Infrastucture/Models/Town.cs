using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Models
{
    public class Town
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? CountryId { get; set; }
        public virtual Country? Country { get; set; }
        public virtual ICollection<Hotel>? Hotels { get; set; }
        public virtual ICollection<Recommendation>? Recommendations { get; set; }
    }
}
