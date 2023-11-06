using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {           
           /*
            * Так работает с контруктором по умолчанию
            Person person1 = new Person();
            Person person2 = new();
            var person3 = new Person();
            var person4 = new Person() { Name = "Фёдор", Height = 200, Birthday = DateTime.Now};
            Person person5 = new() { Name = "Сёдор", Height = 200, Birthday = DateTime.Now };
           */
            //var person1 = new Person("Фёдор", DateTime.Now.AddDays(1));
            //var person2 = new Person("Фёдор", DateTime.Now.AddDays(-1));
            Console.WriteLine("Hello, World!");

            //person1.Print();
            //person2.Print();

            //Console.WriteLine(person1.IsAdult());
            //Console.WriteLine(person2.IsAdult(21));

            //Person son = new Person("Николай", DateTime.Parse("01.01.1977"));
            //Person daughter = new Person("Николаша", DateTime.Parse("01.01.1978"));
            //Person father = new Person("Николаша", DateTime.Parse("01.01.1950"));
            //Person mother = new Person("Николаша", DateTime.Parse("01.01.1952"));

            //person1.AddFamily(father, mother, daughter, son);
            //person2.AddFamily(father, mother, son, son, son, son, son);

            //    person1.PrintFamilyInfo();
            //    person2.PrintFamilyInfo();

            /*
            string s1 = "123";
            string s2 = "fgh";

            int i1 = int.Parse(s1);
            Console.WriteLine(i1);

            if (int.TryParse(s2, out int i2))
            {
                Console.WriteLine(i2);
            }
            else
                Console.WriteLine($"{s2} - не число!");
            */

            //var res = person1.GetChildren(out Person[] children);
            //if (res == true)
            //{
            //    Console.WriteLine("Дети есть");
            //}

            SomeData sm1 = new SomeData();
            SomeData sm2 = new SomeData();

            sm1.data = 5;
            sm2.data = 5;

            //CopyAndModifyData(sm1);
            //ModifyData(ref sm2);

            var someClass = new SomeClass(10);
            Console.WriteLine($" {someClass.SomeProperty}, {someClass.SomeProperty1} ," +
                $"{someClass.SomeProperty2} ");

            var someClass2 = new SomeClass(10) { SomeProperty1 = 30};
            Console.WriteLine($" {someClass2.SomeProperty}, {someClass2.SomeProperty1} ," +
                $"{someClass2.SomeProperty2} ");

            //someClass2.SomeProperty1 = 40;
            //Console.WriteLine($" {someClass.SomeProperty}, {someClass.SomeProperty1} ," +
            //    $"{someClass.SomeProperty2} ");
            someClass2.SomeProperty2 = 40;
            Console.WriteLine($" {someClass.SomeProperty}, {someClass.SomeProperty1} ," +
                $"{someClass.SomeProperty2} ");


            var ae = new AdultAge();
            ae.Age = 10;
            Console.WriteLine(ae.Age);

            Console.WriteLine(new AdultAge().Day);



            Console.WriteLine("****************************************");
            Console.WriteLine();
            var woman = new Woman("Анна", DateTime.Parse("01.01.1990"));
            var man = new Man("Олег", DateTime.Parse("01.01.1990"));

            woman.Print();
            woman.PutMakeup();
            woman.RemoveMakeup();

            man.Print();
            man.Shave();

            Person[] people = new Person[] { man, woman };
            foreach( Person person in people)
            {
                person.Print(); 
                if(person is Woman)
                {
                    (person as Woman)?.PutMakeup();
                    (person as Man)?.Shave();
                }
            }

            foreach (Person person in people)
            {
                person.Print();
                person.SayHello();
            }

            foreach (Person person in people)
            {
                person.SayHelloPhrase();
            }
            Console.WriteLine("----------------");
            man.SayHelloLikeParent();
            woman.SayHelloPhrase();

            Person p = man;
            p.Print();
            man.Print();
        }
    }
}