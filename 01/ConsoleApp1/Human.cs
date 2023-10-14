using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Gender
    {
        men, women
    }

    enum Member
    {
        father, mather, son, doughter, grandMather, grandFather
    }
    public class Human
    {
        public string name { get; set;}
        public string surname {  get; set;} 
        public string gender { get; set;}
        public DateTime birthday {  get; set;}
        public Human mather {  get; set;}
        public Human father { get; set; }
        public Human son { get; set; }
        public Human doughter { get; set; }

        public Human(string surename, string name, string gender, DateTime birthdayr)
        {
            this.name = surename;
            this.surname = name;
            this.gender = gender;
            this.birthday = birthday;
        }

        public Human(string surename, string name, string gender, DateTime birthday, Human mather, Human father, Human son, Human doughter)
        {
            this.name = surename;
            this.surname = name;
            this.gender = gender;
            this.birthday = birthday;
            this.mather = mather;
            this.father = father;
            this.son = son;
            this.doughter = doughter;
        }

        public void Print()
        {
            Console.WriteLine(@$"Surname: {surname}, name: {name}, gen: {gender}, birthday: {birthday},
mather: {mather}, father: {father},
son: {son}, doughter: {doughter}
");
        }
    }
}
