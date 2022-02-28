using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacityCalculation
{
    public class Cabinet
    {
        public string Name { get; set; }
        public int SignalAI { get; set; }
        public int SignalDI { get; set; }
        public int SignalAO { get; set; }
        public int SignalDO { get; set; }
        public int SignalRS485PLK { get; set; }
        public int SignalRS485SHL { get; set; }

    }
}
