using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Family
    {
        Human Owner { get; set; }
        Human Father { get; set; }
        Human Mather { get; set; }
        Human Son { get; set; }
        Human Doughter { get; set; }
       

        public Family(Human Owner, Human Father, Human Mather, Human Son, Human Doughter, Human GrandMather, Human GrandFather)
        {
            this.Owner = Owner;
            this.Father = Father;
            this.Mather = Mather;
            this.Son = Son;
            this.Doughter = Doughter;
        }
        public void PrintFamily()
        {
            Console.WriteLine($"Owner: {Owner}, Father: {Father}, Mather: {Mather}, Son: {Son}, Doughter: {Doughter}");
        }
        
    }
}
