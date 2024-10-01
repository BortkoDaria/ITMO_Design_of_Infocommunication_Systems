using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    abstract class RouteFinder
    {
        public string Title { get; set; }
        public abstract void FindingARoute();
    }

    class CarRoute : RouteFinder
    {
        public CarRoute() 
        { 
            Title = "Автомобильный маршрут";
        }

        public override string ToString()
        {
            return Title;
        }

        public override void FindingARoute()
        {
            Console.WriteLine("Автомобильный маршрут построен");
        }
    }
    class WalkingRoute : RouteFinder
    {
        public WalkingRoute()
        {
            Title = "Пеший маршрут";
        }

        public override string ToString()
        {
            return Title;
        }

        public override void FindingARoute()
        {
            Console.WriteLine("Пеший маршрут построен");
        }
    }
    class CyclingRoute : RouteFinder
    {
        public CyclingRoute()
        {
            Title = "Велосипедный маршрут";
        }

        public override string ToString()
        {
            return Title;
        }

        public override void FindingARoute()
        {
            Console.WriteLine("Велосипедный маршрут построен");
        }
    }
    class PublicTransportRoute : RouteFinder
    {
        public PublicTransportRoute()
        {
            Title = "Маршрут на общественном транспорте";
        }

        public override string ToString()
        {
            return Title;
        }

        public override void FindingARoute()
        {
            Console.WriteLine("Маршрут на общественном транспорте построен");
        }
    }
    class SightseeingRoute : RouteFinder
    {
        public SightseeingRoute()
        {
            Title = "Маршрут через достопримечательности";
        }

        public override string ToString()
        {
            return Title;
        }

        public override void FindingARoute()
        {
            Console.WriteLine("Маршрут через достопримечательности построен");
        }
    }

    class Context
    {
        RouteFinder finder;

        public Context(RouteFinder finder)
        {
            this.finder = finder;
        }

        public void FindARoute()
        {
            finder.FindingARoute();
            Console.WriteLine("Отображение маршрута на карте");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RouteFinder f1 = new WalkingRoute();
            Context c1 = new Context(f1);
            c1.FindARoute();

            RouteFinder f2 = new SightseeingRoute();
            Context c2 = new Context(f2);
            c2.FindARoute();
            Console.Read();
        }
    }
}
