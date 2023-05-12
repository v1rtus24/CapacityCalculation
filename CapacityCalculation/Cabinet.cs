using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        public string Other { get; set; }
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
        public Cabinet(int signalAI, int signalDI, int signalAO, int signalDO, int signalRS485PLK, int signalRS485SHL)
        {
            Name = "";
            SignalAI = signalAI;
            SignalDI = signalDI;
            SignalAO = signalAO;
            SignalDO = signalDO;
            SignalRS485PLK = signalRS485PLK;
            SignalRS485SHL = signalRS485SHL;
        }
        // ДЛЯ ЛОКАЛКИ//////////////////////////////////////////////////////////////////////////////////
        //Плюсуем резерв к кусту и возвращаем шкаф с резервом
        public static Cabinet Rezerv(Cabinet cab)
        {
            return new Cabinet((int)Math.Ceiling(cab.SignalAI + cab.SignalAI * 0.2), (int)Math.Ceiling(cab.SignalDI + cab.SignalDI * 0.3),
                (int)Math.Ceiling(cab.SignalAO + cab.SignalAO * 0.2), (int)Math.Ceiling(cab.SignalDO + cab.SignalDO * 0.3),
                cab.SignalRS485PLK, cab.SignalRS485SHL);
        }

        //ПОДБОР ШКАФА
        public static Cabinet PodborCab(Cabinet WellPad,List<Cabinet> cabs)
        {
            List<Cabinet> cabinets = new List<Cabinet>();
            foreach(var cab in cabs)
            {
                if (MoreSignal(cab, WellPad))
                    cabinets.Add(cab);
            }

            List<int> AverSignal = new List<int>();
            foreach(var a in cabinets)
            {
                AverSignal.Add(AverageSignal(a));
            }
            int min = AverSignal.Min();
            return cabinets[AverSignal.IndexOf(min)];
        }





        // ДЛЯ ЛОКАЛКИ//////////////////////////////////////////////////////////////////////////////////

        public int AverageSignal()
        {
            double s = (double)((SignalAI + SignalDI + SignalAO + SignalDO + SignalRS485PLK + SignalRS485SHL) / 6);
            return (int)Math.Round(s);
        }
        public static int AverageSignal(Cabinet cabinet)
        {
            double s = (double)((cabinet.SignalAI + cabinet.SignalDI + cabinet.SignalAO + cabinet.SignalDO + cabinet.SignalRS485PLK + cabinet.SignalRS485SHL) / 6);
            return (int)Math.Round(s);
        }

        public static int RazSig(Cabinet cab1,Cabinet cab2)
        {
            return (cab1.SignalAI - cab2.SignalAI) + (cab1.SignalDI - cab2.SignalDI) + (cab1.SignalAO - cab2.SignalAO) +
                (cab1.SignalDO - cab2.SignalDO) + (cab1.SignalRS485PLK - cab2.SignalRS485PLK) + (cab1.SignalRS485SHL - cab2.SignalRS485SHL);
        }
        public static bool  MoreSignal(Cabinet cab1, Cabinet cab2)
        {
            if (cab1.SignalAI >= cab2.SignalAI && cab1.SignalDI >= cab2.SignalDI &&
                    cab1.SignalAO >= cab2.SignalAO && cab1.SignalDO >= cab2.SignalDO &&
                    cab1.SignalRS485PLK >= cab2.SignalRS485PLK && cab1.SignalRS485SHL >= cab2.SignalRS485SHL)
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
        public static Cabinet FilterAllSignal(List<Cabinet> typeCabs, Cabinet curCab)
        {
            List<int> razTypeCabs = new List<int>();
            Cabinet cab;
            foreach (var a in typeCabs)
            {
                razTypeCabs.Add(Cabinet.RazSig(a, curCab));
            }
            int minRaz = razTypeCabs[0];
            int ind = 0;
            // находим минимальную разницу всех сиганлов и соблюдаем условие 
            for (int i = 0; i < typeCabs.Count; i++)
            {
                if (minRaz > razTypeCabs[i] && Cabinet.MoreSignal(typeCabs[i], curCab))
                {
                    minRaz = razTypeCabs[i];
                    ind = i;
                }
            }
            cab = typeCabs[ind];
            return cab;
        }
    }
}
