using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04
{
    internal class Tripl
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public Tripl()
        {
        }

        public Tripl(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public int SumTripl()
        {
            return a + b + c;
        }

        public void PrintTripl()
        { 
            Console.WriteLine($"T^:{a}:{b}:{c};");
        }


    }
}
