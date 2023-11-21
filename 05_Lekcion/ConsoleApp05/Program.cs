namespace ConsoleApp05
{
    delegate void MyDelegate();
    class Exampl
    {
        public void SayHelloExampl()
        {
            Console.WriteLine("Привет, я - делегат из Exampl!!!");
        }
    }
    internal class Program
    {

        static void SayHello2(string name)
        {
            Console.WriteLine($"Привет, {name}!!!");
        }
        static void SayHello()
        {
            Console.WriteLine("Привет, я - делегат!!!");
        }
        static void SayWatsup()
        {
            Console.WriteLine("Что нового?");
        }
        static void SayBye()
        {
            Console.WriteLine("делегат - Пока!!!");
        }

        // Захват переменных
        static void AnatherMethod(Action method)
        {
            method();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine();
            Console.WriteLine("Delegate ******************");
            Console.WriteLine();
            MyDelegate? myDelegate1 = new MyDelegate(SayHello);
            MyDelegate? myDelegate2 = SayHello;
            MyDelegate myDelegate3 = SayWatsup;

            //myDelegate1();
            //myDelegate2();

            myDelegate1 = myDelegate1 + SayBye; ;
            myDelegate2 = myDelegate2 + SayBye;

            myDelegate2 -=  SayBye; // myDelegate2 = myDelegate2 - SayBye;
            myDelegate2 = myDelegate2 + SayWatsup + SayBye;

            myDelegate1();
            myDelegate2();

            Console.WriteLine(myDelegate2.GetInvocationList().Length);

            var methodsList = myDelegate2.GetInvocationList();
            foreach(MyDelegate meth in methodsList)
            {
                Console.WriteLine("Вызываем метод ");
                meth();
            }

            Console.WriteLine($"target - {myDelegate2.Target}");

            var ex = new Exampl();
            MyDelegate? myDelegate4 = new MyDelegate(ex.SayHelloExampl);
            Console.WriteLine($"target - {myDelegate4.Target}");


            Console.WriteLine();
            Console.WriteLine(" Анонимный метод / Захват переменных ******************");
            Console.WriteLine();

            int counter = 0;

            var method = delegate() // создание анонимного метода
            {
                Console.WriteLine($"Значение counter = {counter}");
                counter++;
            };
            method();
            method();
            method();

            counter = -1;

            AnatherMethod(method);
            Console.WriteLine();


            Console.WriteLine("Лямбда выражения ******************");
            Console.WriteLine();

            var funcion = (int x) => x * 2;
            var action = () => Console.WriteLine($"Привет, ");

            List<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            
            //foreach (int i in ints.Where((int x) => x % 2 == 0))
            foreach (int i in ints.Where(x => x%2 == 0))
            {
                Console.WriteLine(i);
            }

            //Action<string> action1 = SayHello;
            
            Action<string> action1 = (string name) => SayHello2(name);
            Action<string> action2 = (_) => Console.WriteLine("Привет!");
            Action<string> action3 = (string name) => Console.WriteLine($"Привет, {name}!!!");

            action1("Андрей");
            action2("Андрей");
            action3("Андрей");






            Console.WriteLine();
            Console.WriteLine("******************");
            Console.WriteLine();



        }
    }
}