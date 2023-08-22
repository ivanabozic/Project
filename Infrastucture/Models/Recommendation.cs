﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Models
{
    public class Recommendation
    {
        public string? Id { get; set; }
        public Country? Destination { get; set; }
        public float Price { get; set; }
        public DateTime Departure { get; set; }
    }
}
