﻿using System;
using System.Collections;
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
        public Cabinet() { }
        public Cabinet(string name, int signalAI, int signalDI, int signalAO, int signalDO, int signalRS485PLK, int signalRS485SHL)
        {
            Name = name;
            SignalAI = signalAI;
            SignalDI = signalDI;
            SignalAO = signalAO;
            SignalDO = signalDO;
            SignalRS485PLK = signalRS485PLK;
            SignalRS485SHL = signalRS485SHL;
        }
        
        public int AverageSignal()
        {
            double s = (SignalAI + SignalDI + SignalAO + SignalDO + SignalRS485PLK + SignalRS485SHL) / 6;
            return (int)Math.Round(s);
        }
        
        public static int RazSig(Cabinet cab1,Cabinet cab2)
        {
            return (cab1.SignalAI - cab2.SignalAI) + (cab1.SignalDI - cab2.SignalDI) + (cab1.SignalAO - cab2.SignalAO) +
                (cab1.SignalDO - cab2.SignalDO) + (cab1.SignalRS485PLK - cab2.SignalRS485PLK) + (cab1.SignalRS485SHL - cab2.SignalRS485SHL);
        }
        public static bool  MoreSignal(Cabinet cab1, Cabinet cab2)
        {
            if (cab1.SignalAI > cab2.SignalAI && cab1.SignalDI > cab2.SignalDI &&
                    cab1.SignalAO > cab2.SignalAO && cab1.SignalDO > cab2.SignalDO &&
                    cab1.SignalRS485PLK > cab2.SignalRS485PLK && cab1.SignalRS485SHL > cab2.SignalRS485SHL)
                return true;
            else
                return false;
        }
        public static List<Cabinet> FilterSignal(List<Cabinet> typeCabs, Cabinet curCab, TypeSignal typeSignal)
        {

            List<Cabinet> cabs = new List<Cabinet>();
            List<Cabinet> cabinets = typeCabs;
            List<int> minSignals = new List<int>();

            if (typeSignal == TypeSignal.AI)
            {
                foreach (var a in cabinets)
                {
                    minSignals.Add(a.SignalAI);
                }
                minSignals.Sort();
                for (int i = 0; i < cabinets.Count; i++)
                {
                    if (minSignals[0] >= cabinets[i].SignalAI && Cabinet.MoreSignal(cabinets[i], curCab))
                    {
                        cabs.Add(cabinets[i]);
                    }
                }

            }
            if (typeSignal == TypeSignal.DI)
            {
                foreach (var a in cabinets)
                {
                    minSignals.Add(a.SignalDI);
                }
                minSignals.Sort();
                for (int i = 0; i < cabinets.Count; i++)
                {
                    if (minSignals[0] >= cabinets[i].SignalDI && Cabinet.MoreSignal(cabinets[i], curCab))
                    {
                        cabs.Add(cabinets[i]);
                    }
                }

            }
            if (typeSignal == TypeSignal.AO)
            {
                foreach (var a in cabinets)
                {
                    minSignals.Add(a.SignalAO);
                }
                minSignals.Sort();
                for (int i = 0; i < cabinets.Count; i++)
                {
                    if (minSignals[0] >= cabinets[i].SignalAO && Cabinet.MoreSignal(cabinets[i], curCab))
                    {
                        cabs.Add(cabinets[i]);
                    }
                }

            }
            if (typeSignal == TypeSignal.DO)
            {
                foreach (var a in cabinets)
                {
                    minSignals.Add(a.SignalDO);
                }
                minSignals.Sort();
                for (int i = 0; i < cabinets.Count; i++)
                {
                    if (minSignals[0] >= cabinets[i].SignalDO && Cabinet.MoreSignal(cabinets[i], curCab))
                    {
                        cabs.Add(cabinets[i]);
                    }
                }
            }
            if (typeSignal == TypeSignal.RS485PLK)
            {
                foreach (var a in cabinets)
                {
                    minSignals.Add(a.SignalRS485PLK);
                }
                minSignals.Sort();
                for (int i = 0; i < cabinets.Count; i++)
                {
                    if (minSignals[0] >= cabinets[i].SignalRS485PLK && Cabinet.MoreSignal(cabinets[i], curCab))
                    {
                        cabs.Add(cabinets[i]);
                    }
                }
            }
            if (typeSignal == TypeSignal.RS485SHL)
            {
                foreach (var a in cabinets)
                {
                    minSignals.Add(a.SignalRS485SHL);
                }
                minSignals.Sort();
                for (int i = 0; i < cabinets.Count; i++)
                {
                    if (minSignals[0] >= cabinets[i].SignalRS485SHL && Cabinet.MoreSignal(cabinets[i], curCab))
                    {
                        cabs.Add(cabinets[i]);
                    }
                }

            }
            return cabs;
        }

    }
}
