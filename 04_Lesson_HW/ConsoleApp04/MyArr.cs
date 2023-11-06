using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp04
{
    internal class MyArr
    {
        public int FindNum;
        public int MaxSizeOfArr;
        public int MinNumOfArr;
        public int MaxNumOfArr;
        
        public int[]? Arr;
        

        public int[] GenerateMyArr(int MaxSizeOfArr, int MinNumOfArr, int MaxNumOfArr)
        {
            Random Rnd = new Random();
            
            int[] arr = new int[Rnd.Next(3, MaxSizeOfArr)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Rnd.Next(MinNumOfArr, MaxNumOfArr);
            }
            return arr;
        }

        public int[] SortMyArr(int[] Arr)
        {
            return Arr.OrderBy(x => x).ToArray(); ;
        }

        public int FindTriplSum(int FindNum, int[]arr)
        {
            if (FindNum > arr.Max() * 3) {
                Console.WriteLine("Нет решений!");
                return 0; 
            }
            arr = SortMyArr(arr);
            Tripl tripl = new Tripl();
            int count = 0;
            int countRez = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < FindNum)
                {
                    tripl.a = arr[i];
                    for (int j = i; j < arr.Length; j++)
                    {
                        if (i == j) continue;
                        if (arr[j] < FindNum - tripl.a)
                        {
                            tripl.b = arr[j];
                            for (int k = j; k < arr.Length; k++)
                            {
                                if (k == i || k == j) continue;
                                tripl.c = arr[k];
                                if (arr[k] <= FindNum - tripl.a - tripl.b)
                                {
                                    if (FindNum == tripl.SumTripl())
                                    {
                                        Console.Write(" - OK " + tripl.SumTripl() + ": ");
                                        tripl.PrintTripl();
                                        
                                        //Console.WriteLine();
                                        count++; 
                                        countRez++;
                                    }
                                    else
                                    {
                                        //tripl.PrintTripl();
                                        count++;
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }

            }
            if (countRez == 0) Console.WriteLine("Нет решений!!!");
            return count;
        }


        public void PrintMyArr(int[] Arr)
        {
            Console.Write("[");
            for(int i = 0;  i < Arr.Length; i++)
            {
                Console.Write(Arr[i]);
                if (i < Arr.Length-1) Console.Write(", ");
            }
            Console.WriteLine("]");
        }

    }
}
