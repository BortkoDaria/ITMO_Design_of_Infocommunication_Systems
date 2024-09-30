using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    abstract class Progression
    {
        public int First { get; set; }
        public int Last { get; set; }
        public int H { get; set; }
        public List<int> progList;
        public Progression(int first, int last, int h)
        {
            First = first;
            Last = last;
            H = h;
            progList = new List<int>();
        }
        public void TemplateMethod()
        {
            InitializeProgression(First, Last, H);
            Progress();
            Print(progList);
        }
        private void Print(List<int> progList)
        {
            Console.WriteLine("Последовательность:");
            foreach (var item in progList)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
        }
        private void InitializeProgression(int a, int b, int h)
        {
            First = a;
            Last = b;
            H = h;
        }
        public abstract void Progress();

    }

    class ArithmeticProgression : Progression
    {
        public ArithmeticProgression(int f, int l, int h) : base(f, l, h) { }
        public override void Progress()
        {
            int fF = First;
            do
            {
                progList.Add(fF);
                fF = fF + H;
            }
            while (fF < Last);
        }
    }
    class GeometricProgression : Progression
    {
        public GeometricProgression(int f, int l, int h) : base(f, l, h) { }
        public override void Progress()
        {
            int fF = First;
            do
            {
                progList.Add(fF);
                fF = fF * H;
            }
            while (fF < Last);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int f, l, h;
            Console.WriteLine("Введите нижнюю границу диапазона: ");
            f = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите верхнюю границу диапазона: ");
            l = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите шаг прогрессии: ");
            h = Convert.ToInt32(Console.ReadLine());
            Progression val = new ArithmeticProgression(f, l, h);
            Console.WriteLine("Арифметическая прогрессия");
            val.TemplateMethod();
            Progression val2 = new GeometricProgression(f, l, h);
            Console.WriteLine("Геометрическая прогрессия");
            val2.TemplateMethod();
            Console.Read();
        }
    }
}
