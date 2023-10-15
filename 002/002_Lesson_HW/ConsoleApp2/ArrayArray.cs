using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ArrayArray
    {
        public static void PrintArrayArray(int[,] a)
        {
            Console.Write("[");
            for (int i = 0; i < a.GetLength(0); i++) {
                Console.Write("[");
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (j != a.GetLength(1)-1) { Console.Write($" {a[i, j]},"); }
                    else Console.Write($" {a[i, j]}");
                }
                if (i != a.GetLength(0) - 1) { Console.WriteLine("],"); }
                else Console.WriteLine("]]");
            }
        }

        public static int[,] SortToMaxArrayArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    for (int n = 0; n < a.GetLength(0); n++)
                    {
                        for (int m = 0; m < a.GetLength(1); m++)
                        {
                            if (a[i, j] < a[n, m])
                            {
                                int temp = a[i, j];
                                a[i, j] = a[n, m];
                                a[n, m] = temp;
                            }
                        }
                    }
                }
            }
            return a;
        }
    }
}
