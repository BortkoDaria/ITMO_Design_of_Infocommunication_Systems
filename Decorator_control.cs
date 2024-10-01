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
    public abstract class AutoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double CostBase { get; set; }
        public abstract double GetCost();
        public override string ToString()
        {
            string s = String.Format("Ваш автомобиль: \n{0} \nОписание: {1} \nСтоимость {2}\n",
            Name, Description, GetCost());
            return s;
        }
    }
    class Renault : AutoBase
    {
        public Renault(string name, string info, double costbase)
        {
            Name = name;
            Description = info;
            CostBase = costbase;
        }
        public override double GetCost()
        {
            return CostBase * 1.18;
        }
    }

    class Audi : AutoBase
    {
        public Audi(string name, string info, double costbase)
        {
            Name = name;
            Description = info;
            CostBase = costbase;
        }
        public override double GetCost()
        {
            return CostBase * 1.18;
        }
    }
    abstract class DecoratorOptions : AutoBase
    {
        public AutoBase AutoProperty { protected get; set; }
        public string Title { get; set; }
        public DecoratorOptions(AutoBase au, string tit)
        {
            AutoProperty = au;
            Title = tit;
        }
    }
    class MediaNAV : DecoratorOptions
    {
        public MediaNAV(AutoBase p, string t) : base(p, t)
        {
            AutoProperty = p;
            Name = p.Name + ". Современный";
            Description = p.Description + ". " + this.Title + ". Обновленная мультимедийная навигационная система";
        }
        public override double GetCost()
        {
            return AutoProperty.GetCost() + 150.99;
        }
    }
    class SystemSecurity : DecoratorOptions
    {
        public SystemSecurity(AutoBase p, string t) : base(p, t)
        {
            AutoProperty = p;
            Name = p.Name + ". Повышенной безопасности";
            Description = p.Description + ". " + this.Title + ". Передние боковые подушки безопасности, ESP -система динамической стабилизации автомобиля";
        }
        public override double GetCost()
        {
            return AutoProperty.GetCost() + 200.99;
        }
    }

    class Maintenance : DecoratorOptions
    {
        public Maintenance(AutoBase p, string t) : base(p, t)
        {
            AutoProperty = p;
            Name = p.Name + ". Повышенной надежности";
            Description = p.Description + ". " + this.Title + ". Год бесплатного технического обслуживания в сертифицированных сервиcных центрах";
        }
        public override double GetCost()
        {
            return AutoProperty.GetCost() + 400.99;
        }
    }

    class ExtendedTrunk : DecoratorOptions
    {
        public ExtendedTrunk (AutoBase p, string t) : base(p, t)
        {
            AutoProperty = p;
            Name = p.Name + ". Повышенной вместительности";
            Description = p.Description + ". " + this.Title + ". Увеличенный багажник для комфортных поездок всей семьей";
        }
        public override double GetCost()
        {
            return AutoProperty.GetCost() + 1000.99;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Renault reno = new Renault("Рено", "Renault LOGAN Active", 499.0);
            Print(reno);
            AutoBase myreno = new MediaNAV(reno, "Навигация");
            Print(myreno);
            AutoBase newmyReno = new SystemSecurity(new MediaNAV(reno, "Навигация"), "Безопасность");
            Print(newmyReno);

            Console.WriteLine();

            Audi audi = new Audi("Ауди", "Audi A3", 28500.0);
            Print(audi);
            AutoBase myaudi = new ExtendedTrunk(audi, "Вместительность");
            Print(myaudi);
            AutoBase mynewaudi = new Maintenance(new ExtendedTrunk(audi, "Вместительность"), "Надежность");
            Print(mynewaudi);
            Console.Read();
        }
        private static void Print(AutoBase av)
        {
            Console.WriteLine(av.ToString());
        }

    }
}
