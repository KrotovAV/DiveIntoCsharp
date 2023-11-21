using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp06
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException()
        {

        }

        public NegativeNumberException(string message) : base(message)
        {

        }

        public NegativeNumberException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
