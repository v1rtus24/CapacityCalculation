using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CapacityCalculation
{
    public class WellPad
    {
        public int Num { get; set; }
        public List<TecObject> tecObjects { get; set; }
        public WellPad(int num) 
        { 
            Num = num;
            tecObjects = new List<TecObject>();
        }    
        public int WellCount(TypeTecObj typeTecObj)
        {
            int count = 0;
            if (tecObjects.Count > 0)
            {
                foreach (var tec in tecObjects)
                {
                    if (tec.Type == typeTecObj)
                    {
                        count++;
                    }
                }
                return count;
            }
            else { return 0; }
        }
        //Подсчёт всех сигналов по отдельности на кусте ( ШЛЮЗ УЧИТЫВАЕТСЯ НА ГРУППУ СКВАЖИН И ОТДЕЛЬНО ОТ ИУ)
        public Cabinet SignalCount(int prodWell,int injWell)
        {
            int AI = 0, DI = 0, AO = 0, DO = 0, RS485PLK = 0, RS485SHL = 0;
            int IU;
            if (prodWell + injWell > 14)
                IU = 2;
            else 
                IU = 1;
            //АИ от доб скважин
            AI += prodWell * 2;
            //АИ от нагн скважин
            AI += injWell * 2;
            //АИ от нефтегазового коллектора
            AI += 1;
            //АИ от шкафа ПС
            AI += 3;

            //DI от доб скважин и нагн
            DI += prodWell + injWell * 2;
            //DI от УДЭ
            DI += 3;
            //DI от ШКАФА ОС
            DI += 3;
            //DI от НКУ ШУО
            DI += 2;
            //DI от емкостей дренажных
            DI += IU;
            //DI от ДФКУ КТП ( одна на каждые 4 скважины)
            double KTP = Math.Ceiling((double)(prodWell + injWell)/4);
            DI += (int)KTP;
            //RS485 ПЛК от нефтегаз трубопровода и УДЭ
            RS485PLK += 2;
            //RS485 ШЛЮЗ ОТ ИУ
            RS485SHL += IU;
            //RS485 ШЛЮЗ ОТ СУ ЭЦН( 1 сигнал от каждыйх 6 СУ ЭЦН(СУ ЭЦН на каждую скважину)
            double SUECN = Math.Ceiling((double)(prodWell + injWell)/6);
            RS485SHL += (int)SUECN;
            return new Cabinet(AI,DI,AO,DO,RS485PLK,RS485SHL);
        }

    }
}
