using ConsoleApp05;

namespace ConsoleApp062
{
    internal class Program
    {
        /* Задача 4
        Доработайте реализацию калькулятора разработав собственные 
        типы ошибок. 
        Например:
        CalculatorDivideByZeroException 
        CalculateOperationCauseOverflowException


        В прошлой раз мы реализовали метод CancelLast позволяющий 
        отменить любое сделанное действие. Реализуйте класс - список, 
        описывающий последовательность действий приведших исключению. 
        Очевидно что класс калькулятора должен быть доработан чтобы 
        хранить не только информацию необходимую нам для отмены но 
        и информацию о самом действии. 
        Продумайте как лучше это реализовать.

        */

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