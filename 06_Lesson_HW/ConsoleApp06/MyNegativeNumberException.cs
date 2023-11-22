using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp06
{
    public class MyNegativeNumberException : Exception
    {
        public MyNegativeNumberException()
        {
        }
        public MyNegativeNumberException(string message) : base(message)
        {
        }
        public MyNegativeNumberException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
