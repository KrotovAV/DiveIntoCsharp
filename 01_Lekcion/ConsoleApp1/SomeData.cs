using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public struct SomeData
    {
        public int data;
        static void CopyAndModifyData(SomeData someData)
        {
            someData.data = 10;
        }
        static void ModifyData(ref SomeData someData)
        {
            someData.data = 10;
        }
    }
}
