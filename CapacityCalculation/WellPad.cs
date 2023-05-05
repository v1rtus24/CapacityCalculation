using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacityCalculation
{
    public class WellPad
    {
        public int Num { get; set; }
        public List<Well> Wells { get; set; }
        public WellPad(int num) 
        { 
            Num = num;
            Wells= new List<Well>();
        }    
    }
}
