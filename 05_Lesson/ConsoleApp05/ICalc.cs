using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp05
{
    public interface ICalc
    {
        double Result { get; set; }
        void Sum(int x);
        void Sub(int x);
        void Mult(int x);
        void Div(int x);
        void CancelLast();

        event EventHandler<EventArgs> MyEventHandler;






    }
}
