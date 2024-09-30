using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    interface IGame
    {
        int Brosok();
    }
    class Kost : IGame
    {
        Random r;

        public Kost()
        {
            r = new Random();
        }
        public int Brosok()
        {
            // Случайное число от 1 до 6.
            int res = r.Next(6) + 1;
            return res;
        }
    }
    class Monet
    {
        Random r;

        public Monet()
        {
            r = new Random();
        }
        public int BrosokM()
        {
            //Случаное число 1 или 2.
            int res = r.Next(2) + 1;
            return res;
        }
    }
    class AdapterGame : IGame
    {
        Monet mot;
        public AdapterGame(Monet mt)
        {
            mot = mt;
        }
        public int Brosok()
        {
            return mot.BrosokM();
        }
    }
    class Gamer
    {
        public string Name { get; set; }
        public Gamer(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
        public int SeansGame(IGame ig)
        {
            return ig.Brosok();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Kost kubik = new Kost();
            Gamer g1 = new Gamer("Иван");
            Console.WriteLine("Выпало очков {0} для игрока {1}", g1.SeansGame(kubik), g1.ToString());
            Monet mon = new Monet();

            IGame bmon = new AdapterGame(mon);
            Console.WriteLine("Монета показала \"{0}\" для игрока {1}", g1.SeansGame(bmon),
           g1.ToString());

            Console.Read();
        }
    }
}
