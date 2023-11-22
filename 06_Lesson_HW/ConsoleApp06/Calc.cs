using ConsoleApp06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ConsoleApp06
{
    internal class Calc : ICalc
    {
        public double Result { get; set; } = 0;
        private Stack<double> LastResult { get; set; } = new Stack<double>();
        private Stack<string> IntoRead { get; set; } = new Stack<string>();
        public event EventHandler<EventArgs> MyEventHandler;

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
        public void CancelLast()
        {
            if (LastResult.TryPop(out double res))
            {
                IntoRead.Pop();
                if (LastResult.TryPeek(out res))
                    Result = res;
                PrintResult();
            }
            else
            {
                Console.WriteLine("Невозможно отменить последнее действие");
            }
        }
        public void Calculate(char charX, double x)
        {
            try
            {
                Check.NegativeNumber(x);
            }
            catch (MyNegativeNumberException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Что бы исправить на {Math.Abs(x)}, нажмите у\n" +
                    $"что бы продолжить с {x} нажмите любую клавишу");
                string? questionToAbs = Console.ReadLine();
                if (questionToAbs != null)
                {
                    if (questionToAbs.Equals("y"))
                    {
                        x = Math.Abs(x);
                        Console.WriteLine($"Значение изменено на {x}");
                    }
                }
            }
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
                    try
                    {
                        Check.ZeroeNumber(x);
                    }
                    catch (MyDivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    Div(x);
                    break;
                case '*':
                    Mult(x);
                    break;
                case '=':
                    Сompl();
                    break;
            }
            try
            {
                Check.NegativeNumber(Result);
            }
            catch (MyNegativeNumberException ex)
            {
                CancelLast();
                Console.WriteLine(ex.Message);
            }
        }
        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }
    }
}
