using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacityCalculation
{
    public class Signal
    {
        public string NameSignal { get; set; }  
        public string TypeSignal { get; set; }
        public Signal(string nameSignal, string type) 
        {
            NameSignal = nameSignal;
            TypeSignal = type;
        }
    }
}
