using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SomeClass
    {
        public int SomeProperty {  get; init; }
        public int SomeProperty1 { get; init; } = 20;
        public int SomeProperty2 { get; set; }
        public int SomeProperty3 { get { return SomeProperty * 2; } }
        public SomeClass(int someProperty)
        {
            this.SomeProperty = someProperty;
            
        }


    }
}
