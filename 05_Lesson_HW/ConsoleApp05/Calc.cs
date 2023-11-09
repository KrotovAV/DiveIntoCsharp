using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp05
{
    internal class Calc : ICalc
    {
        public double Result { get; set; } = 0;
        private Stack<double> LastResult { get; set; } = new Stack<double>();
        private Stack<string> IntoRead { get; set; } = new Stack<string>();
        public event EventHandler<EventArgs> MyEventHandler;

        public static List<char> operands = new List<char> { '+', '-', '*', '/', '=', '#' };

        public void Div(double x)
        {
            Result /= x;
            LastResult.Push(Result);
            IntoRead.Push("/ " + x);
            PrintResult();
        }
        public void Mult(double x)
        {
            Result *= x;
            LastResult.Push(Result);
            IntoRead.Push("* " + x);
            PrintResult();
        }
        public void Sum(double x)
        {
            Result += x;
            LastResult.Push(Result);
            IntoRead.Push("+ " + x);
            PrintResult();
        }
        public void Sub(double x)
        {
            Result -= x;
            LastResult.Push(Result);
            IntoRead.Push("- " + x);
            PrintResult();
        }
        public void Start(double x)
        {
            Result = x;
            LastResult.Push(Result);
            IntoRead.Push($"{Result}");
            PrintResult();
        }

       
        public void Сompl()
        {
            Stack<string> IntoReadRevers = new Stack<string>(IntoRead);
            foreach (string elem in IntoReadRevers)
            {
                Console.Write(elem + " ");
            }
            Console.Write("= ");
            PrintResult();
        }

        public void Calculate(char charX, double x) 
        {
            Console.WriteLine("------");
            switch (charX)
            {
                case '#':
                    CancelLast();
                    break;
                case '\0':
                    Start(x);
                    break;
                case '+':
                    Sum(x);
                    break;
                case '-':
                    Sub(x);
                    break;
                case '/':
                    Div(x);
                    break;
                case '*':
                    Mult(x);
                    break;
                case '=':
                    Сompl();
                    break;
            }
        }

        public void CancelLast()
        {            
            if (LastResult.TryPop(out double res))
            {
                IntoRead.Pop();
                if(LastResult.TryPeek(out res))
                Result = res;       
                PrintResult();
            }
            else
            {
                Console.WriteLine("Невозможно отменить последнее действие");
            }
        }
        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }

        public char Parser(string read, out double x)
        {
            char retChar;
            read.Replace(" ", "");

            if (read.Length > 0)
            {
                if (operands.Contains(read[0]))
                {
                    retChar = read[0];
                    read.Remove(0, 1);
                }
                else
                {
                    retChar = '\0';
                }
                if (read.Length != 0)
                {
                    if (double.TryParse(new string(read.Where(t => char.IsDigit(t)).ToArray()), out x));
                }
                else x = 0;

            }
            else
            {
                Console.WriteLine("Ошибка ввода! Нужно ввести действие и число!");
                retChar = ' ';
                x = 0;
            }
            return retChar;
        }
    }
}
