using System.Linq.Expressions;

namespace ConsoleApp05
{
    internal class Program
    {
        private static void Calc_MyEventHandler(object? sender, EventArgs e)
        {
            if (sender is Calc)
            Console.WriteLine(((Calc)sender).Result);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Calc calc = new Calc();
            calc.MyEventHandler += Calc_MyEventHandler;

            Console.WriteLine();
            Console.WriteLine("*********************");
            Console.WriteLine("Введите действие и число, нажмите Enter! \n" +
                "Для отмены действия, введите '#', нажмите Enter! \n" +
                "Для завершения введите '=', нажмите Enter");
            char retChar = ' ';
            double x;
            while (retChar != '=')
            {
                retChar = calc.Parser(Console.ReadLine(), out x);
                calc.Calculate(retChar, x);
            }
            Console.WriteLine();
            Console.WriteLine("*********************");
            Console.WriteLine();



        }
    }
}