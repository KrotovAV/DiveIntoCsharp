using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp062
{
    public class CalcOperationCauseOverflowException : CalcException
    {
        public CalcOperationCauseOverflowException() 
        { 
        }
        public CalcOperationCauseOverflowException(string message) : base (message) 
        {
        }
    }
}
