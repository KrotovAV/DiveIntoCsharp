using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp06
{
    internal class MyDivideByZeroException : Exception
    {
        public MyDivideByZeroException()
        {
        }
        public MyDivideByZeroException(string message) : base(message)
        {
        }
    }
}
