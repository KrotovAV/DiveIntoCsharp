using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp062
{
    public class CalcDivideByZeroException : CalcException
    {
        public CalcDivideByZeroException() 
        { 
        }
        public CalcDivideByZeroException(string message) : base(message) 
        {
        }
    }
}
