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
        Human Owner;
        Human WifeHusband { get; set; }
        Human Father { get; set; }
        Human Mather { get; set; }
        //List<Human> Children;
        Human Son { get; set; }
        Human Doughter { get; set; }
        Human GrandMather { get; set; }
        Human GrandFather { get; set; }

        //Human NoMan = new Human("NoNown", "NoNown", "NoNown", new DateOnly(0001, 01, 01));
        public Family(Human Owner, Human wifeHusband, Human father, Human mather, Human son, Human doughter, Human grandFather, Human grandMather)
        {
            this.Owner = Owner;
            this.WifeHusband = wifeHusband;
            this.Father = father;
            this.Mather = mather;
            this.Son = son;
            this.Doughter = doughter;
            this.GrandFather = grandFather;
            this.GrandMather = grandMather;
            
        }
        public string PrintOwnerFamily()
        {
            return  $"Owner: {Owner.Surname} {Owner.Name}, {Owner.Gender} {Owner.Birthday}, \n" +
                $"Wife/Husband: {WifeHusband.Surname} {WifeHusband.Name}, \n" +
                $"Father: {Father.Surname} {Father.Name}, Mather: {Mather.Surname} {Mather.Name}, \n" +
                $"Son: {Son.Surname} {Son.Name}, Doughter: {Doughter.Surname} {Doughter.Name}, \n" +
                $"GrandFather: {GrandFather.Surname} {GrandFather.Name}, GrandMather: {GrandMather.Surname} {GrandMather.Name}\n";
        }
        
    }
}
