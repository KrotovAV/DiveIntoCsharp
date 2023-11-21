using System;

namespace ConsoleApp06
{
    internal class Program
    {
        

        static int DivideTwoNum(int n1, int n2)
        {
            return n1 / n2;
        }
        static int DivideTwoNumbers(int n1, int n2)
        {
            try
            {
                return n1 / n2;
            }
            catch
            {
                Console.WriteLine("Ошибка деления на нуль!");
                return default(int);
            }
        }
        static bool TryDivideTwoNumbers(int n1, int n2, out int res)
        {
            try
            {
                res = n1 / n2;
                return true;
            }
            catch
            {
                Console.WriteLine("Ошибка деления на нуль!");
                res = default(int);
                return false;
            }
        }

        static int[] DivideTwoArrays(int[] arr1, int[] arr2)
        {
            int l = Math.Min(arr1.Length, arr2.Length);
            int[] resArr = new int[l];
            for (int i = 0; i < arr1.Length; i++)
            {
                resArr[i] = arr1[i] / arr2[i];
            }
            return resArr;
        }
        static void RunDivideTwoArrays(int[] arr1, int[] arr2)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("* RunDivideTwoArrays *");
                int[] resultArray = DivideTwoArrays(arr1, arr2);

                foreach (var i in resultArray)
                {
                    Console.WriteLine(i + " ");
                }
            }
            catch (Exception e) when (false)
            {
                Console.WriteLine("Возникла ошибка деления на нуль " + e.Message);
            }
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine("Возникла ошибка деления на нуль " + e.Message);
            //}
            //catch (ArithmeticException e)
            //{
            //    Console.WriteLine("Возникла арефмитическая ошибка " + e.Message);
            //}
            //catch (IndexOutOfRangeException e)
            //{
            //    Console.WriteLine("Возникла ошибка выхода индеккса за границу диаппазона" + e.Message);
            //}
            //catch (NullReferenceException e)
            //{
            //    Console.WriteLine("Один из массивов равен null " + e.Message);
            //}
        }
         private static void CurrentDomain_FirstChanceException (object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception);
        }
        private static void CurrentDomain_UnhandledException (object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject);
        }
       
        static void Main(string[] args)
        {

            Console.WriteLine();
            Console.WriteLine("Исключения *****************************");
            Console.WriteLine();

            int a = 5;
            int b = 0;

            if (TryDivideTwoNumbers(a, b, out int res))
            {
                Console.WriteLine(res);
            }
            else
                Console.WriteLine("Не удалось разделить число на нуль!");

            Console.WriteLine("-----------");
            try
            {
                var res2 = DivideTwoNum(a, b);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Не удалось разделить число на нуль! {e}");
            }
            Console.WriteLine();
            Console.WriteLine("Приложение продолжит работать");

            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            int[] AArr = new int[] { 4, 12, 24};
            int[] BArr = null;
            int[] CArr = new int[] { 2, 4, 0 };
            int[] DArr = new int[] { };

            RunDivideTwoArrays(AArr, AArr);
            RunDivideTwoArrays(AArr, BArr);
            RunDivideTwoArrays(AArr, CArr);
            RunDivideTwoArrays(AArr, DArr);

            Console.WriteLine();
            Console.WriteLine("Приложение продолжит работать");









            Console.WriteLine();
            Console.WriteLine("*****************************");
            Console.WriteLine();
        }
    }
}