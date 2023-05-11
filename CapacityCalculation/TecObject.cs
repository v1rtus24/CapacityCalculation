using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CapacityCalculation
{
    public class TecObject
    {
        public string Name { get; set; }
        public TypeTecObj Type { get; set; }
        public int SignalAI { get; set; } = 0;
        public int SignalDI { get; set; } = 0;
        public int SignalAO { get; set; } = 0;
        public int SignalDO { get; set; } = 0;
        public int SignalRS485PLK { get; set; } = 0;
        public int SignalRS485SHL { get; set; } = 0;
        public string Info { get; set; } = "";
        public TecObject(TypeTecObj type)
        {
            Type= type;
            switch (type)
            {
                case TypeTecObj.DobSkvaz:
                    Name = "Добывающая скважина";
                    SignalAI = 2; SignalDI = 1; SignalRS485SHL = 1;
                    Info = "2 AI - датчики измерения затрубного и буферного давления; 1 DI - сигнал Состояние ЭЦН от СУ ЭЦН; 1 подключение RS-485 к шлюзу от СУ ЭЦН.";
                    break;
                case TypeTecObj.NagnSkvaz:
                    Name = "Нагнетательная скважина (с отработкой на добычу)";
                    SignalAI = 2; SignalDI = 2; SignalRS485SHL = 1;
                    Info = "2 AI - датчики измерения затрубного и буферного давления (для отработки на нефть); 1 DI - сигнал от расходомера; 1 DI - сигнал Состояние ЭЦН от СУ ЭЦН; 1 подключение RS-485 к шлюзу от СУ ЭЦН.";
                    break;
                case TypeTecObj.EmkPodzDren:
                    Name = "Емкость подземная дренажная";
                    SignalDI = 1;
                    Info = "1 DI - сигнализатор уровня в емкости.";
                    break;
                case TypeTecObj.NagnCol:
                    Name = "Нагнетательный коллектор";
                    SignalAI = 1;
                    Info = "1 AI - датчик давления в общем коллекторе (на входе на куст).";
                    break;
                case TypeTecObj.NeftegazTrub:
                    Name = "Нефтегазосборный трубопровод от ИУ";
                    SignalRS485PLK = 1;
                    Info = "1 RS-485 в ПЛК - Подключение задвижки с электроприводом на выходе КП";
                    break;
                case TypeTecObj.IzmUst:
                    Name = "Измерительная установка";
                    SignalRS485SHL = 1;
                    Info = "1 RS-485 - Передача данных в СТМ в обход ПЛК с помощью преобразования интерфейсов";
                    break;
                case TypeTecObj.UDE:
                    Name = "УДЭ";
                    SignalDI = 3; SignalRS485PLK = 1;
                    Info = "3 DI - Открытие двери, Авария, Насос включен; 1 RS-485 в ПЛК - передача данных УДЭ в СТМ.";
                    break;
                case TypeTecObj.DFKU:
                    Name = "ДФКУ";
                    SignalDI = 1;
                    Info = "1 DI Работа/Останов.";
                    break;
                case TypeTecObj.BlokContNKU:
                    Name = "Блок контейнер НКУ";
                    SignalDI = 2;
                    Info = "2 DI Обогрев включен, Аварийное отключение.";
                    break;
                case TypeTecObj.CabPS:
                    Name = "Шкаф ПС";
                    SignalAI = 3;
                    Info = "3 AI - Пожар (общий), Пожар в ИУ, Неисправность (подключение к аналоговым модулям для контроля на обрыв и КЗ).";
                    break;
                case TypeTecObj.CabOS:
                    Name = "Шкаф ОС";
                    SignalDI = 3;
                    Info = "3 DI -Тревога (общий),Тревога ТМПН и СУ, Неисправность.";
                    break;
            }
        }
    }
}
