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
        public event EventHandler<EventArgs> MyEventHandler;

        public void Div(int x)
        {
            Result /= x;
            LastResult.Push(Result);
            PrintResult();
        }
        public void Mult(int x)
        {
            Result *= x;
            LastResult.Push(Result);
            PrintResult();
        }
        public void Sum(int x)
        {
            Result += x;
            LastResult.Push(Result);
            PrintResult();
        }
        public void Sub(int x)
        {
            Result -= x;
            LastResult.Push(Result);
            PrintResult();
        }

        public void CancelLast()
        {
            if (LastResult.TryPop(out double res))
            {
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


    }
}
