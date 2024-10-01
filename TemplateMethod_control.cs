using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    abstract class Haircut
    {
        public int StartLength { get; set; }
        public int EndLength { get; set; }
        public Haircut(int sl, int el)
        {
            StartLength = sl;
            EndLength = el;
        }
        public void TemplateMethod()
        {
            InitializeProcess();
            Haircutting(StartLength, EndLength);
            Payment();
        }
        public void InitializeProcess()
        {
            Console.WriteLine("Обсуждение деталей с клиентом");
        }

        public abstract void Haircutting(int sl, int el);
        public void Payment() {
            Console.WriteLine("Оплата услуги");
        }
    }

    class ModelHaircut : Haircut
    {
        public ModelHaircut(int sl, int el) : base(sl, el) { }

        public override void Haircutting(int sl, int el)
        {
            Console.WriteLine("Стрижка по определенной технологии, исходная длина: {0}, итоговая длина: {1}",
                this.StartLength, this.EndLength);
        }
    }

    class TrimmingHairEnds : Haircut
    {
        public TrimmingHairEnds(int sl, int el) : base(sl, el) { }

        public override void Haircutting(int sl, int el)
        {
            Console.WriteLine("Подравнивание кончиков, исходная длина: {0}, итоговая длина: {1}",
                this.StartLength, this.EndLength);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Haircut hc1 = new ModelHaircut(80, 60);
            hc1.TemplateMethod();

            Console.WriteLine("");

            Haircut hc2 = new TrimmingHairEnds(120, 115);
            hc2.TemplateMethod();

            Console.Read();
        }
    }
}
