using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp07
{
    public class TestClass
    {
        public int I { get; set; }
        public int A { get; set; }
        public string? S { get; set; }
        public decimal D { get; set; }
        public char[]? C { get; set; }
        public char[]? CC { get; set; }
        public TestClass()
        {

        }
        public TestClass(int i)
        {
            I = i;
        }
        public TestClass(int i, int a, string s, decimal d, char[] c, char[] cc) : this(i)
        {
            A = a;
            S = s;
            D = d;
            C = c; 
            CC = cc;
        }

    }
}
