﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalsWP
{
    public class UDE
    {
        public int SignalAI { get; set; } = 0;
        public int SignalDI { get; set; } = 3;
        public int SignalAO { get; set; } = 0;
        public int SignalDO { get; set; } = 0;
        public int SignalRS485PLK { get; set; } = 1;
        public int SignalRS485SHL { get; set; } = 0;
    }
}
