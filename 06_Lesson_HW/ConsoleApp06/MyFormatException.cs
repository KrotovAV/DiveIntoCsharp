using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp06
{
    internal class MyFormatException : Exception
    {
        public MyFormatException()
        {
        }
        public MyFormatException(string message) : base(message)
        {
        }
    }
}
