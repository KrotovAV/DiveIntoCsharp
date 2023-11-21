using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp062
{
    public class CalcException : Exception
    {
        public CalcException()
        {
        }
        public CalcException(string message) : base(message)
        {
        }
    }
}
