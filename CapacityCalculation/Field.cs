using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacityCalculation
{
    public class Field
    {
        public List<WellPad> WellPads { get; set; }
        public string Name { get; set; }
        public Field(string name)
        {
            Name = name;
            WellPads= new List<WellPad>();
        }
    }
}
