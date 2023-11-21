using ConsoleApp1;
using System.Net.Mail;

namespace ConsoleApp02
{
    internal class Program
    {
        static void TakeCare(params IBabySitter[] sitters)
        {
            foreach (var sitter in sitters)
            {
                sitter.TakeCare();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            Person[] people = new Person[]
            {
                new Woman("Анна",DateTime.Parse("01.01.1990")),
                new Woman("Мария",DateTime.Parse("01.01.1980")),
                new Woman("Светлана",DateTime.Parse("01.01.1991")),
                new Woman("Екатерина",DateTime.Parse("01.01.1993")),
                new Man("Алексей",DateTime.Parse("01.01.1992"))

            };
            Array.Sort(people);
            foreach (Person person in people)
            {
                person.Print();
            }

            var man = new Man("Олег", DateTime.Parse("01.01.1990"));
            var woman = new Woman("Анна", DateTime.Parse("01.01.1990"));
            var kid = new Man("Федор", DateTime.Parse("01.01.1990"));


            man.TakeCare();
            woman.TakeCare();

            Console.WriteLine();
            Console.WriteLine("1 ****************************************");
            Console.WriteLine();

            man.AddFamilyInfo(null, null, kid);
            woman.AddFamilyInfo(null, null, kid);

            man.TakeCare();
            woman.TakeCare();

            IBabySitter babySitter = woman;
            IParent mom = woman;
            IParent dad = man;

            Console.WriteLine();
            Console.WriteLine("2 ****************************************");
            Console.WriteLine();

            mom.TakeCare();
            babySitter.TakeCare();

            IBabySitter babySitter1 = new BabySitter();
            var babySitter2 = new BabySitter();
            IBabySitter babySitter3 = new BabySitter();

            Console.WriteLine();
            Console.WriteLine("3 ****************************************");
            Console.WriteLine();

            TakeCare(babySitter, babySitter1, babySitter2, babySitter3);

            Console.WriteLine();
            Console.WriteLine("4 ****************************************");
            Console.WriteLine();

            var grandPa = new Man("Николайг", DateTime.Parse("01.01.1970"));
            var grandMa = new Woman("Вера", DateTime.Parse("01.01.1975"));

            var parent = new Woman("Анна", DateTime.Parse("01.01.1990"));
            var kidA = new Man("Олег", DateTime.Parse("01.01.2000"));

            parent.AddFamilyInfo(grandPa, grandMa, kidA);

            for (int i = 0; i < parent.Count; i++)
            {
                parent[i].Print();
            }
            Console.WriteLine();
            Console.WriteLine("5 ****************************************");
            Console.WriteLine();


            Person person1 = new Man("Миша", DateTime.Parse("01.01.2000"));
            Person person2 = new Man("Ваня", DateTime.Parse("01.01.2001"));
            Person person3 = new Man("Коля", DateTime.Parse("01.01.2002"));

            var groupOf3 = new { Name1 = person1.Name, Name2 = person2.Name, Name3 = person3.Name };

            Console.WriteLine(groupOf3);

            var groupOf2 = new { person1.Name, person2.Birthday };

            Console.WriteLine(groupOf2);


            Console.WriteLine();
            Console.WriteLine("6 Generic интерфейсы **************************");
            Console.WriteLine();

            IUser<int> user1 = new User<int>(6789);
            Console.WriteLine(user1.Id);    // 6789

            IUser<string> user2 = new User<string>("12345");
            Console.WriteLine(user2.Id);    // 12345
        }
    }
}