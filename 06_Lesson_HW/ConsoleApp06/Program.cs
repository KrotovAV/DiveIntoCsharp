using ConsoleApp06;

namespace ConsoleApp06
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

            Calc calc = new Calc();
            calc.MyEventHandler += Calc_MyEventHandler;

            Console.WriteLine();
            Console.WriteLine("*********************");
            Console.WriteLine("P.s. Наш калькулятор используется для вычисления длинн, периметров, площадей и объемов \n" +
                "в гражданском строительстве и является встроенным в приложение для архитекторов \n" +
                "по проектированию и рассчету необходимого количества строительных материалов, объемов работ и т.д. \n" +
                "т.е. все Результаты вычислений должны быть неотрицательными величинами.");
            Console.WriteLine("*********************");
            Console.WriteLine();
            Console.WriteLine("Введите действие и число, нажмите Enter! \n" +
                "Для отмены действия, введите '#', нажмите Enter! \n" +
                "Для завершения введите '=', нажмите Enter");
            char retChar = ' ';
            double x;
            while (retChar != '=')
            {
                retChar = MyParse.Parser(Console.ReadLine(), out x);
                calc.Calculate(retChar, x);
            }

            Console.WriteLine();
            Console.WriteLine("*********************");
            Console.WriteLine();
        }
    }
}