using System.Text;

namespace ConsoleApp06
{
    internal class Program
    {
        public static bool MyTryParse(string myString, out int num)
        {
            num = 0;
            try
            {
                num = Convert.ToInt32(myString);
                return true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false; 
            }
        }
        public static void ProcessNumber(int number)
        { 
            if (number < 0)
            {
                throw new NegativeNumberException("Число вне области допустимых значений ", new Exception("Тестовая строка " ));
            }
            Console.WriteLine(number);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            // Задача 1
            // Написать собственную реализацию TryParse и FormatException вывести на экран
            string text = "123";
            int res;
            if(MyTryParse(text, out res))
            {
                Console.WriteLine(res);
            }

            if (MyTryParse("123fg", out res))
            {
                Console.WriteLine(res);
            }


            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine();
            /* Задача 2
             Создайте класс исключения NegativeNumberException, который будет использоваться при
             попытке выполнения операции, не поддерживающей отрицательные числа.
             */
            int number21 = 12;
            try
            {
                ProcessNumber(number21);
            }
            catch (NegativeNumberException  ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());
            }
            catch { }
            Console.WriteLine();



            int number22 = -4;
            try
            {
                ProcessNumber(number22);
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("---");
                Console.WriteLine(ex.Message);
                Console.WriteLine("---");
                Console.WriteLine(ex.ToString());
            }
            catch { }



            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine();

            /* Задача 3
             Асланов Добавьте обработку собственного исключения, а также кода, 
             который обрабатывает вложенное исключение(InnerException) для 
             предоставления более детальной информации.
             */

            int number31 = -4;
            try
            {
                ProcessNumber(number22);
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("***");
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
            catch { }


            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine();

            /* Задача 4
            Доработайте реализацию калькулятора разработав собственные 
            типы ошибок. 
            Например:
            CalculatorDivideByZeroException 
            CalculateOperationCauseOverflowException

            */




            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine();
        }
    }
}