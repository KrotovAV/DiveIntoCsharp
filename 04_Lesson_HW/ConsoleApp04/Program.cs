using System.ComponentModel.Design;

namespace ConsoleApp04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            //int FindNum = 12;

            
            MyArr myArr = new MyArr();
            int[] arr = myArr.GenerateMyArr(25, 0, 100);
            myArr.PrintMyArr(arr);


            Random Rnd = new Random();
            int findNumber = Rnd.Next(0, arr.Max() * 4);
            //int findNumber = FindNum;
            int FindNum = findNumber;
            Console.WriteLine("Сумма 3-ёх элементов для поиска = " + findNumber);
            int count = myArr.FindTriplSum(findNumber, arr);
            Console.WriteLine("Ппроверено вариантов: " + count);

        }

    }
}
