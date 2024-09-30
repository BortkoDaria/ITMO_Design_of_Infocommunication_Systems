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
    class ClimatControl
    {
        public void checkRoomTemp (Measuring ms)
        {
            double temp = ms.CheckTemperature();
            if (temp < 18)
                Console.WriteLine("{0} degree is too cold, the room needs to be heated", temp);
            else if (temp > 22)
                Console.WriteLine("{0} degree is too hot, the room needs to be cooled down", temp);
            else
                Console.WriteLine("{0} degree is perfect temperature", temp);
        }
    }

    interface Measuring
    {
        double CheckTemperature();
    }

    class MeasuringAdapter : Measuring
    {
        TemperatureSensor sensor;

        public MeasuringAdapter (TemperatureSensor sensor)
        {
            this.sensor = sensor;
        }

        public double CheckTemperature()
        {
            return Math.Round((sensor.CheckTemperatureF()-32)/1.8);
        }
    }
    class TemperatureSensor
    {
        Random r;

        public TemperatureSensor()
        {
            r = new Random();
        }
        
        public double CheckTemperatureF()
        {
            double temp = r.Next(40, 80);
            return temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ClimatControl cc = new ClimatControl();
            TemperatureSensor sensorF = new TemperatureSensor();
            Measuring sensor = new MeasuringAdapter(sensorF);
            for (int i = 0; i< 5; i++)
                cc.checkRoomTemp(sensor);
            Console.Read();
        }

    }
}
