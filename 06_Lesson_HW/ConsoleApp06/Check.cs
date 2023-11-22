using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp06
{
    class Check
    {
        internal static void ZeroeNumber(double number)
        {
            if (number == 0)
            {
                throw new MyDivideByZeroException("Деление на нуль невозможно ");
            }
        }
        internal static void NegativeNumber(double number)
        {
            if (number < 0)
            {
                throw new MyNegativeNumberException($"Результат {number} вне области допустимых значений ");
            }
        }
    }
}
