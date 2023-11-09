using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography;

namespace ConsoleApp04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7};
            var numbers2 = numbers.MyWhere<int>(x => x > 3);

            //foreach (var number in numbers2) 
            //{ 
            //    Console.WriteLine(number);
            //}

            /*Задача 1: 
            Фильтрация и проекция данных с использованием LINQ
            Предоставьте студентам некоторую коллекцию объектов(например, список студентов) и 
            попросите их решить следующие задачи:

                Найти всех студентов, чей возраст меньше 25 лет.
                Вывести имена всех студентов в алфавитном порядке.
                Выбрать студентов, обучающихся на факультете инженерии.
                Посчитать средний возраст студентов.
                Попросите студентов использовать LINQ для решения этих задач.
            */

            List<Student> students = new List<Student>
            {
            new Student { Name = "Alice", Age = 22, Faculty = "Engineering" },
            new Student { Name = "Bob", Age = 25, Faculty = "Science" },
            new Student { Name = "Charlie", Age = 19, Faculty = "Engineering" },
            new Student { Name = "David", Age = 30, Faculty = "Arts" },
            new Student { Name = "Eve", Age = 21, Faculty = "Science" },
            // Добавьте других студентов по вашему усмотрению
            };

            var findAge = students.Where(x => x.Age < 25);
            var sortName = students.OrderBy(x => x.Name).Select(x => x.Name);
            var findEngeners = students.Where(x => x.Faculty.Equals("Engineering"));
            var averageAge = students.Average(x => x.Age);

            findAge.ToList().ForEach(x => Console.WriteLine($"{x.Name}- {x.Age}"));
            Console.WriteLine();
            sortName.ToList().ForEach(x => Console.WriteLine($"{x}, "));
            Console.WriteLine();
            findEngeners.ToList().ForEach(x => Console.WriteLine($"{x.Name}- {x.Faculty}"));
            Console.WriteLine();
            Console.WriteLine(averageAge);
            Console.WriteLine();
            Console.WriteLine("************************");


            /* Задача 2.
            21 Отсортировать заказы по сумме в убывающем порядке.
            22 Сгруппировать заказы по клиентам и вывести количество заказов для каждого клиента.
            23 Найти клиента с наибольшей суммой заказов.
            24 Вывести список клиентов и общую сумму их заказов.
            Попросите студентов использовать LINQ для сортировки и группировки данных.
            */

            List<Order> orders = new List<Order>
            {
                new Order { OrderID = 1, CustomerName = "Alice", OrderDate = new DateTime(2023, 6, 1), TotalAmount = 150.0 },
                new Order { OrderID = 2, CustomerName = "Bob", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 75.5 },
                new Order { OrderID = 3, CustomerName = "Charlie", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 220.0 },
                new Order { OrderID = 4, CustomerName = "David", OrderDate = new DateTime(2023, 6, 3), TotalAmount = 100.0 },
                new Order { OrderID = 5, CustomerName = "Eve", OrderDate = new DateTime(2023, 6, 4), TotalAmount = 85.5 },
                new Order { OrderID = 6, CustomerName = "Bob", OrderDate = new DateTime(2023, 6, 3), TotalAmount = 95.5 },
                new Order { OrderID = 7, CustomerName = "Bob", OrderDate = new DateTime(2023, 6, 4), TotalAmount = 105.5 },
            };
            //21
            var sortSum = orders.OrderByDescending(x => x.TotalAmount);
            var sortSum2 = from order in orders
                           orderby order.TotalAmount descending
                           select order;
            //22
            var groupAmountByName = orders.GroupBy(x => x.CustomerName).Select(x => new { name = x.Key, count = x.Count() });
            //23
            var maxAmount = orders.GroupBy(x => x.CustomerName)
                .Select(x => new { name = x.Key, sumAmount = x.Sum(y => y.TotalAmount) })
                .OrderBy(y => y.sumAmount).Last().name ;
            //24
            var clientMaxAmount = orders.GroupBy(x => x.CustomerName)
                .Select(x => new { name = x.Key, sumAmount = x.Sum(y => y.TotalAmount) });

            sortSum.ToList().ForEach(x => Console.WriteLine($"{x.CustomerName} - {x.TotalAmount}"));
            Console.WriteLine();
            sortSum2.ToList().ForEach(x => Console.WriteLine($"{x.CustomerName} - {x.TotalAmount}"));
            Console.WriteLine();

            groupAmountByName.ToList().ForEach(x => Console.WriteLine($"{x.name} - {x.count}"));
            Console.WriteLine();

            Console.WriteLine(maxAmount);
            Console.WriteLine();

            clientMaxAmount.ToList().ForEach(x => Console.WriteLine($"{x.name} - {x.sumAmount}"));
            Console.WriteLine();
            Console.WriteLine("************************");

            /*Задача 3
            Есть список строк, и ваша задача – отсортировать этот список в порядке возрастания 
            длины строк, используя лямбда-выражение. Ниже приведены начальные данные и возможное решение:
            */

            List<string> strings = new List<string>
                {
                "Apple",
                "Banana",
                "Cherry",
                "Date",
                "Fig",
                "Grapes"
                };

            var sortString = strings.OrderBy(x => x.Length).ToList();
            sortString.ForEach(Console.WriteLine);
            Console.WriteLine("************************");

            

            List<int> myNumbers = new List<int> { 1, 2, 3, 45, 4, 87, 8, 9, 25, 5, 68, 6, 85, 27, 15, 16, 20 };
            myNumbers.Sort();
            myNumbers.ForEach(Console.WriteLine);
            Console.WriteLine();
            myNumbers.Sort((x,y) => x.CompareTo(y));
            myNumbers.ForEach(Console.WriteLine);
            Console.WriteLine();
            Console.WriteLine("************************");

            /* Задача 4
            Выбрать все строки, содержащие определенную подстроку, 
            с использованием лямбда-выражения. 
            Вот начальные данные и решение задачи:
            */

            List<string> fruits = new List<string>
                {
                "Apple",
                "Banana",
                "Cherry",
                "Date",
                "Fig",
                "Grapes"
                };

            string searchStr = "a";

            var fruitsSearhStrRes = fruits.Where(x => x.Contains(searchStr)).ToList();
            fruitsSearhStrRes.ForEach(Console.WriteLine);
            Console.WriteLine();
            fruits.Where(x => x.Contains(searchStr)).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
            
            Console.WriteLine("************************");

            /* Задача 5
            Есть список чисел, и мы хотим умножить каждое число в списке на 2, используя анонимный метод
            */


            List<int> myNumbers2 = new List<int> { 1, 2, 3, 45, 4, 87, 8, 9, 25, 5, 68, 6, 85, 27, 15, 16, 20 };

            List<int> myNumbersPow2 = myNumbers2.Select(x => x * 2).ToList();

            myNumbers2.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            myNumbersPow2.ForEach(x => Console.Write(x +" "));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("************************");

            /* Задача 6
            Есть список объектов, и мы хотим отфильтровать этот список по определенному критерию, 
            используя лямбда-выражение.

            имя клиента начинается с буквы А
            */

            string searchStartName = "A";
            List<Order> orders2 = new List<Order>
            {
                new Order { OrderID = 1, CustomerName = "Alice", OrderDate = new DateTime(2023, 6, 1), TotalAmount = 150.0 },
                new Order { OrderID = 2, CustomerName = "Bob", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 75.5 },
                new Order { OrderID = 3, CustomerName = "Charlie", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 220.0 },
                new Order { OrderID = 4, CustomerName = "David", OrderDate = new DateTime(2023, 6, 3), TotalAmount = 100.0 },
                new Order { OrderID = 5, CustomerName = "Eve", OrderDate = new DateTime(2023, 6, 4), TotalAmount = 85.5 },
                new Order { OrderID = 6, CustomerName = "Bob", OrderDate = new DateTime(2023, 6, 3), TotalAmount = 95.5 },
                new Order { OrderID = 7, CustomerName = "Bob", OrderDate = new DateTime(2023, 6, 4), TotalAmount = 105.5 },
            };

            var nameSrartA = orders2.Where(x => x.CustomerName.StartsWith(searchStartName)).ToList();
            nameSrartA.ForEach(x => Console.WriteLine(x.CustomerName));

            Console.WriteLine();
            Console.WriteLine("************************");

            /* Задача 7
            найти одинаковые элементы из двух колекций, 
            используя лямбда-выражение.
            */

            HashSet <int> numHashSet = new HashSet<int> {6, 1, 46, 2, 3, 45, 4, 87, 5, 8, 9 };
            List<int> numList = new List<int> { 1, 2, 3, 4, 43, 5, 6 };

            var result = numHashSet.Intersect(numList).ToList();
            result.ForEach(Console.WriteLine);

        }
    }
}