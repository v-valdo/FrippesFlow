using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrippesFlow.Models
{
    public class ProductionCost
    {
        public long Id { get; set; }
        public double MilkPerLitre { get; set; }
        public double FlourPerKg { get; set; }
        public double YeastPerKg { get; set; }
        public double SaltPerKg { get; set; }
        public double WaterPerM3 { get; set; }
    }
}