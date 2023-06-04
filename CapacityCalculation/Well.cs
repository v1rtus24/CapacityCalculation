using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacityCalculation
{
    public class Well
    {
        public int Num { get; set; }
        public string TypeWell { get; set; }
        public List<Signal> Signals { get; set; }
        public Well(int num,string typeWell) 
        {
            Num = num;
            TypeWell = typeWell;
            Signals = new List<Signal>();
        }
    }
}
