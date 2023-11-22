using ConsoleApp06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp06
{
    public interface ICalc
    {
        double Result { get; set; }
        void Sum(double x);
        void Sub(double x);
        void Mult(double x);
        void Div(double x);
        void CancelLast();

        event EventHandler<EventArgs> MyEventHandler;

    }
}
