using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Person
    {
        public string Name = string.Empty;
        public DateTime Birthday;
        
        public Person Father = null;
        public Person Mother = null;
        public Person[] Children = null;
        protected abstract string HelloPhrase { get; }

        public Person(string name)
        {
            this.Name = name;
            this.Birthday = DateTime.Now;
        }

        public Person(string name, DateTime birthday)
        {
            this.Name = name;

            if (birthday <= DateTime.Now)
                this.Birthday = birthday;
            else
            {
                Console.WriteLine($"дата {Birthday} не верна! Присваивается сегодняшнее!");
                this.Birthday = DateTime.Now;

            }

        }
        public void Print()
        {
            Console.WriteLine($"Имя {Name}, ДР: {Birthday}");
        }
        public bool IsAdult()
        {
            var delta = DateTime.Now.Year - Birthday.Year;
            if (delta > 18 || (delta == 18 && DateTime.Now.DayOfYear <= Birthday.DayOfYear))
            {
                return true;
            }
            else
                return false;
        }
        public bool IsAdult(int adultAge)
        {
            var delta = DateTime.Now.Year - Birthday.Year;
            if (delta > adultAge || (delta == adultAge && DateTime.Now.DayOfYear <= Birthday.DayOfYear))
            {
                return true;
            }
            else
                return false;
        }
        public void AddFamily(Person father, Person mother, params Person[] children)
        {
            Father = father;
            Mother = mother;
            Children = children;
        }
        public void PrintFamilyInfo()
        {
            if (Father != null)
            {
                Console.WriteLine(Father);
                Father.Print();
            }
            if (Mother != null)
            {
                Console.WriteLine(Mother);
                Mother.Print();
            }
            if (Children != null && Children.Length > 0)
            {
                Console.WriteLine("Дети:");
                foreach (var child in Children)
                {
                    child.Print();
                }
            }

        }
        public bool GetChildren(out Person[] children)
        {
            if (Children != null && Children.Length != 0)
            {
                children = Children;
                return true;
            }
            else
            {
                children = null;
                return true;

            }
        }

        public virtual void SayHello()
        {
            Console.WriteLine("Привет, я - человек!!!");
        }

        public void SayHelloPhrase()
        {
            Console.WriteLine(this.HelloPhrase);
        }
    }
}
