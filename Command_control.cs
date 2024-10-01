using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab4
{
    abstract class Command
    {
        protected ArithmeticUnit unit;
        protected double operand;
        public abstract void Execute();
        public abstract void UnExecute();
    }
    class ArithmeticUnit
    {
        public double Register { get; private set; }
        public void Run(char operationCode, double operand)
        {
            switch (operationCode)
            {
                case '+':
                    Register += operand;
                    break;
                case '-':
                    Register -= operand;
                    break;
                case '*':
                    Register *= operand;
                    break;
                case '/':
                    Register /= operand;
                    break;
            }
        }
    }
    class ControlUnit
    {
        private List<Command> commands = new List<Command>();
        private int current = 0;
        public void StoreCommand(Command command)
        {
            commands.Add(command);
        }
        public void ExecuteCommand()
        {
            commands[current].Execute();
            current++;
        }
        public void Undo()
        {
            commands[current - 1].UnExecute();
        }

        public void Undo (int step)
        {
            for (int i = 1; i <= step; i++)
                commands[current - i].UnExecute();
        }
        public void Redo()
        {
            commands[current - 1].Execute();
        }
        public void Redo(int step)
        {
            for (int i = 1; i <= step; i++)
                commands[current - i].Execute();
        }
    }
    class Add : Command
    {
        public Add(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute()
        {
            unit.Run('+', operand);
        }
        public override void UnExecute()
        {
            unit.Run('-', operand);
        }
    }
    class Sub : Command
    {
        public Sub(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute()
        {
            unit.Run('-', operand);
        }
        public override void UnExecute()
        {
            unit.Run('+', operand);
        }
    }
    class Mul : Command
    {
        public Mul(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute()
        {
            unit.Run('*', operand);
        }
        public override void UnExecute()
        {
            unit.Run('/', operand);
        }
    }
    class Div : Command
    {
        public Div(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute()
        {
            unit.Run('/', operand);
        }
        public override void UnExecute()
        {
            unit.Run('*', operand);
        }
    }
    class Calculator
    {
        ArithmeticUnit arithmeticUnit;
        ControlUnit controlUnit;
        public Calculator()
        {
            arithmeticUnit = new ArithmeticUnit();
            controlUnit = new ControlUnit();
        }
        private double Run(Command command)
        {
            controlUnit.StoreCommand(command);
            controlUnit.ExecuteCommand();
            return arithmeticUnit.Register;
        }
        public double Add(double operand)
        {
            return Run(new Add(arithmeticUnit, operand));
        }
        public double Sub(double operand)
        {
            return Run(new Sub(arithmeticUnit, operand));
        }
        public double Mul(double operand)
        {
            return Run(new Mul(arithmeticUnit, operand));
        }
        public double Div(double operand)
        {
            return Run(new Div(arithmeticUnit, operand));
        }
        public double Redo()
        {
            controlUnit.Redo();
            return arithmeticUnit.Register;
        }
        public double Undo()
        {
            controlUnit.Undo();
            return arithmeticUnit.Register;
        }
        public double Redo(int step)
        {
            controlUnit.Redo(step);
            return arithmeticUnit.Register;
        }
        public double Undo(int step)
        {
            controlUnit.Undo(step);
            return arithmeticUnit.Register;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            double result = 0;
            Console.WriteLine("Start with 0");
            Console.WriteLine("+5");
            result = calculator.Add(5);
            Console.WriteLine("= " + result);
            Console.WriteLine("-3");
            result = calculator.Sub(3);
            Console.WriteLine("= " + result);
            Console.WriteLine("*3");
            result = calculator.Mul(3);
            Console.WriteLine("= " + result);
            Console.WriteLine("redo");
            result = calculator.Redo();
            Console.WriteLine("= " + result);
            Console.WriteLine("/2");
            result = calculator.Div(2);
            Console.WriteLine("= " + result);
            Console.WriteLine("redo x 2");
            result = calculator.Redo(2);
            Console.WriteLine("= " + result);

            Console.Read();
        }
    }
}
