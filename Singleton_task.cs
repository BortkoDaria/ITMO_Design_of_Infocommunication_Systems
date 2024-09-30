using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Log
    {
        private Log () { }
        static Lazy<Log> myLog = new Lazy<Log>(() => new Log());

        public static Log MyLog
        {
            get
            {
                return myLog.Value;
            }
        }
        public void LogExecution(string mes)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Loger(mes, w);
                w.Close();
            }
        }
        private static void Loger(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
            DateTime.Now.ToLongDateString());
            w.WriteLine("Действие: {0}", logMessage);
            w.WriteLine("-------------------------------");
        }
    }

    class Operation
    {
        public static double Run(char operationCode, int operand)
        {
            Log lg2 = Log.MyLog;
            double rez = 0;
            switch (operationCode)
            {
                case '+':
                    rez += operand;
                    lg2.LogExecution("Сложение " + operand);
                    break;
                case '-':
                    rez -= operand;
                    lg2.LogExecution("Вычитание " + operand);
                    break;
                case '*':
                    rez *= operand;
                    break;
                case '/':
                case ':':
                    rez /= operand;
                    break;
            }
            return rez;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Log lg = Log.MyLog;
            lg.LogExecution("Метод Main()");
            double op = Operation.Run('-', 35);
            op = Operation.Run('+', 30);
            Console.WriteLine("Логи записаны");
            Console.Read();
        }
    }
}
