using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Models
{
    public class FilterBase
    {
        public int? _page { get; set; }
        public int? _limit { get; set; }
    }
}
