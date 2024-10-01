using lab4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab4
{
    public abstract class ReportBase
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public abstract string MainInfo();
        public override string ToString()
        {
            string s = String.Format("Отчет '{0}' - '{1}' содержит следующую информацию: {2}",
                Title, Subtitle, MainInfo());
            return s;
        }
    }
    class MonthReport : ReportBase
    {
        public MonthReport(string title, string subtitle)
        {
            Title = title;
            Subtitle = subtitle;
        }
        public override string MainInfo()
        {
            return "Information about all transactions per month";
        }
    }
    abstract class DecoratorOptions : ReportBase
    {
        public ReportBase ReportProperty { protected get; set; }
        public string Option { get; set; }
        public DecoratorOptions(ReportBase rep, string opt)
        {
            ReportProperty = rep;
            Option = opt;
        }
    }
    class Statistics : DecoratorOptions
    {
        public Statistics(ReportBase p, string o) : base(p, o)
        {
            ReportProperty = p;
            Option = o;
            Title = p.Title;
            Subtitle = p.Subtitle;
        }
        public override string MainInfo()
        {
            return ReportProperty.MainInfo() + " с добавлением данных из модуля '" + Option + "'. Статистика по передаче данных между агрегаторами";
        }
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            MonthReport mr = new MonthReport("Итоги месяца", "Сентябрь");
            Print(mr);
            ReportBase mrStat = new Statistics(mr, "Статистика");
            Print(mrStat);

            Console.Read();

        }
        private static void Print(ReportBase rep)
        {
            Console.WriteLine(rep.ToString());
        }

    }
}
