using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp05
{
    internal class Program
    {
        //Делегат Action ничего не возвращает и используется с void

        //Делегат Func принимате параметры, а последнем возвращаемое значение 

        //Делегат Predicate проверяет условия для метода, принимает один
        //параметр и возвращает логическое значение bool

        static void Print1()
        {
            Console.WriteLine("111");
        }

        static void Print2()
        {
            Console.WriteLine("222");
        }

        static void doAction(List<Action> lis)
        {
            foreach (var item in lis)
            {
                item();
            }
        }


        delegate void myDelegate(string message);
        static void PrintDelegate(List<myDelegate> lisDel)
        {
            foreach (var item in lisDel)
            {
                item("333");
            }
        }

        private static void Calc_MyEventHandler(object? sender, EventArgs e)
        {
            if (sender is Calc)

                Console.WriteLine(((Calc)sender).Result);
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /*Задача 1
            Создайте метод, который принимает список действий(делегат Action) и 
            выполняет их последовательно.
            */

            List<Action> list = new List<Action>();

            list.Add(Print1);
            list.Add(Print2);
            list.Add(Print1);

            List<myDelegate> myDelegates = new List<myDelegate>()
            {
                (message => Console.WriteLine($"Первый делигат {message}")),
                (message => Console.WriteLine($"Второй делигат {message}"))
            };

            doAction(list);

            PrintDelegate(myDelegates);

            Console.WriteLine();
            Console.WriteLine("*********************");

            /* Задача 2
            Спроектируем интерфейс калькулятора, поддерживающего простые арифметические 
            действия, хранящего результат и также способного выводить информацию о 
            результате при помощи события
            */

            Calc calc = new Calc();

            calc.MyEventHandler += Calc_MyEventHandler;

            calc.Sum(10);
            calc.Sub(2);
            calc.Div(10);
            calc.Mult(4);

            /* Задача 2.1
            Арифметические методы должны выполняться как обычно а метод CancelLast должен 
            отменять последнее действие.При этом метод может отменить последовательно 
            все действия вплоть до самого последнего. Спросите как студенты планируют 
            реализовать отмену действия и если будут трудности с ответами то 
            подскажите им про стек
            */

            calc.Div(10);
            calc.CancelLast();
            calc.CancelLast();
            calc.CancelLast();
            calc.CancelLast();
            calc.CancelLast();
            calc.CancelLast();

            Console.WriteLine();
            Console.WriteLine("*********************");

            /* Задача 3
            Создайте метод, который принимает список строк, функцию (делегат Func) 
            для преобразования строк в числа и действие (делегат Action) для выполнения 
            какого-либо действия с числами.
            */
            static void MyParse(List<string> listStr, Func<string, int> func, Action<int> action)
            {
                foreach (var item in listStr)
                {
                    int res = func(item);
                    action(res);
                }
            }

            List<string> listOfString = new List<string>() { "1", "2", "3" };
            MyParse(listOfString, int.Parse, (x) => Console.WriteLine(x));

            Console.WriteLine();
            Console.WriteLine("*********************");

            /*Задача 4
            Создайте метод, который принимает список чисел и предикат (делегат Predicate), 
            который определяет, соответствует ли каждое число какому-либо условию.
            */


            static void IsAdult(List <string> ages, Func<string, int> func, Predicate< int> predicate, Action <int> action)
            {
                foreach(var age in ages)
                {
                    int res = func(age);
                    if (predicate(res))
                    {
                        action(res);
                    }
                    
                }
            }
            List<string> ageString = new List<string>() { "12", "22", "33", "16", "18", "19" };
            IsAdult(ageString, int.Parse, x => x >= 18, (x) => Console.WriteLine(x));

        }
    }
}