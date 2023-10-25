using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Human
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Gender { get; private set; }
        public DateOnly Birthday { get; private set; }

        public Human(string surename, string name, string gender, DateOnly birthday)
        {
            this.Surname = surename;
            this.Name = name;
            this.Gender = gender;
            this.Birthday = birthday;
        }
        public string PrintHuman()
        {
            return (@$"surname: {Surname}, name: {Name}, gen: {Gender}, birthday: {Birthday}");
        }
    }
}
