using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp09
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public List<Hobby> Hobbies { get; set; }
        public override string ToString()
        {
            return $"Имя: {Name}, " +
                $"Фамилия: {Surname}, " +
                $"Возраст: {Age}, " +
                $"Хобби: {string.Join(", ", Hobbies)}"
                .ToString();
        }
    }
}
