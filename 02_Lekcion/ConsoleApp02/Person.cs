using ConsoleApp02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Person : IComparable, IParent, IFamily
    {
        public string Name = string.Empty;
        public DateTime Birthday;
        
        public Person Father = null;
        public Person Mother = null;
        public Person[] Children = null; 
        protected abstract string HelloPhrase { get; }
        public Person[] Family;
        public int Count => 1 + (Family?.Length ?? 0);

        public Person this[int index] 
        {
            get
            {
                if (index <= 0) return this;
                if(Family is null)
                {
                    return null;
                }
                if (Family.Length >= index)
                {
                    return Family[index - 1];
                }
                return null;
            }
        }

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
        public void AddFamilyInfo(Person father, Person mother, params Person[] children)
        {
            Father = father;
            Mother = mother;
            Children = children;

            int familyCount = 0;

            familyCount += Father == null ? 0 : 1;
            familyCount += Mother == null ? 0 : 1;
            familyCount += Children.Length;

            if (familyCount > 0)
            {
                Family = new Person[familyCount];
            }
            else
                return;
            int counter = 0;
            if(Father != null)
            {
                Family[counter] = Father;
                counter++;
            }
            if (Mother != null)
            {
                Family[counter] = Mother;
                counter++;
            }
            foreach (var child in Children)
            {
                Family[counter] = child;
                counter++;
            }


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

        public int CompareTo(object? obj)
        {
            if(obj == null)
            {
                return -1;
            }
            return this.Birthday.CompareTo((obj as Person).Birthday);
        }

        protected abstract void TakeCareImplementation();
        public void TakeCare()
        {
            if (this.Children != null) 
                TakeCareImplementation();
        }
    }
}
