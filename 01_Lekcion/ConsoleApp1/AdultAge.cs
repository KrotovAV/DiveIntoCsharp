using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AdultAge
    {
        private int age;
        public string Day => DateTime.Now.DayOfWeek.ToString();
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18)
                {
                    age = 18;
                }
                else
                {
                    age = value;
                }
            }
        }
    }
}
