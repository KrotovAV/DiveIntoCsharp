using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp02
{
    internal class BabySitter : IBabySitter
    {
        public void TakeCare()
        {
            Console.WriteLine("Сидит с детьми, пока родители в кинотеатре.");
        }
    }
}
