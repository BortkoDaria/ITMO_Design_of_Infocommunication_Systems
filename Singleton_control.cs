using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{

    abstract class CarFactory
    {
        public abstract AbstractCar CreateCar();
        public abstract AbstractEngine CreateEngine();
    }
    abstract class AbstractCar
    {
        public string Name { get; set; }
        public string BodyType { get; set; }
        public abstract int MaxSpeed(AbstractEngine engine);
    }

    abstract class AbstractEngine
    {
        public int max_speed { get; set; }
    }

    class FordFactory : CarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new FordCar("Форд", "Хэтчбэк");
        }
        public override AbstractEngine CreateEngine()
        {
            return new FordEngine();
        }
    }
    class FordCar : AbstractCar
    {
        public FordCar(string name, string type)
        {
            Name = name;
            BodyType = type;
        }
        public override int MaxSpeed(AbstractEngine engine)
        {
            int ms = engine.max_speed;
            return ms;
        }
        public override string ToString()
        {
            return "Автомобиль " + Name + ", тип кузова: " + BodyType;
        }
    }
    class FordEngine : AbstractEngine
    {
        public FordEngine()
        {
            max_speed = 220;
        }
    }

    class AudiFactory : CarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new AudiCar("Ауди", "Седан");
        }
        public override AbstractEngine CreateEngine()
        {
            return new AudiEngine();
        }
    }

    class AudiCar : AbstractCar
    {
        public AudiCar(string name, string type)
        {
            Name = name;
            BodyType = type;
        }
        public override int MaxSpeed(AbstractEngine engine)
        {
            int ms = engine.max_speed;
            return ms;
        }
        public override string ToString()
        {
            return "Автомобиль " + Name + ", тип кузова: " + BodyType;
        }
    }

    class AudiEngine : AbstractEngine
    {
        public AudiEngine()
        {
            max_speed = 280;
        }
    }

    class TeslaFactory : CarFactory
    {
        private TeslaFactory() { }
        
        static Lazy<TeslaFactory> teslaFactory = new Lazy<TeslaFactory>(() => new TeslaFactory());

        public static TeslaFactory factory { 
            get
            {
                return teslaFactory.Value;
            }
        }

        public override AbstractCar CreateCar()
        {
            return new TeslaCar("Тесла", "Лифтбек");
        }
        public override AbstractEngine CreateEngine()
        {
            return new TeslaEngine();
        }
    }
    class TeslaCar : AbstractCar
    {
        public TeslaCar(string name, string type)
        {
            Name = name;
            BodyType = type;
        }
        public override int MaxSpeed(AbstractEngine engine)
        {
            int ms = engine.max_speed;
            return ms;
        }
        public override string ToString()
        {
            return "Автомобиль " + Name + ", тип кузова: " + BodyType;
        }
    }

    class TeslaEngine : AbstractEngine
    {
        public TeslaEngine()
        {
            max_speed = 262;
        }
    }
    class Client
    {
        private AbstractCar abstractCar;
        private AbstractEngine abstractEngine;
        public Client(CarFactory car_factory)
        {
            abstractCar = car_factory.CreateCar();
            abstractEngine = car_factory.CreateEngine();
        }
        public int RunMaxSpeed()
        {
            return abstractCar.MaxSpeed(abstractEngine);
        }
        public override string ToString()
        {
            return abstractCar.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CarFactory ford_car = new FordFactory();
            Client c1 = new Client(ford_car);
            Console.WriteLine("Максимальная скорость {0} составляет {1} км/час",
            c1.ToString(), c1.RunMaxSpeed());
            
            CarFactory audi_car = new AudiFactory();
            Client c2 = new Client(audi_car);
            Console.WriteLine("Максимальная скорость {0} составляет {1} км/час",
            c2.ToString(), c2.RunMaxSpeed());

            CarFactory tesla_car = TeslaFactory.factory;
            Client c3 = new Client(tesla_car);
            Console.WriteLine("Максимальная скорость {0} составляет {1} км/час",
            c3.ToString(), c3.RunMaxSpeed());
            Console.Read();
        }
    }
}
