using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp03
{
    internal class Program
    {
        //Выведите список чисел на экран, исключив из него повторы.
        public static List<int> GetOnlyUniqNamberFromList(List<int> list)
        {
            List<int> onlyUniqNamber = new List<int>(list.Count);
            foreach(int n in list)
            {
                if (!onlyUniqNamber.Contains(n))
                {
                    onlyUniqNamber.Add(n);
                }
            }
            return onlyUniqNamber;
        }

        /*Дан список целых чисел (числа не последовательны), в котором некоторые числа повторяются.
        Выведите список чисел на экран, расположив их в порядке возрастания частоты повторения*/

        public static List<int> ListSortFriqencyGrow(List<int> list) 
        {
            

            Dictionary<int, int>namberFriqyncyPairs = new Dictionary<int, int>();
            foreach(int n in list)
            {
                if (!namberFriqyncyPairs.ContainsKey(n))//проверяем есть ли ключ с словаре)
                {
                    //если нет то добавляем с частотой 1
                    namberFriqyncyPairs[n] = 1;
                }
                else
                {
                    //если есть то +1 в частоту
                    namberFriqyncyPairs[n] = namberFriqyncyPairs[n] + 1;
                }
            }
            //PrintDictionary(namberFriqyncyPairs);
            Dictionary<int, int> sortNamberFriqyncyPairs = new Dictionary<int, int>();
            sortNamberFriqyncyPairs = namberFriqyncyPairs.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            //PrintDictionary(sortNamberFriqyncyPairs);

            List<int> friqyncyGrow = new List<int>(sortNamberFriqyncyPairs.Count);
            foreach (var i in sortNamberFriqyncyPairs)
            {
                friqyncyGrow.Add(i.Key);
            }        
            return friqyncyGrow;
        }

        /*
         Есть лабиринт описанный в виде двумерного массива где 1 это стены, 0 - проход, 2 - искомая цель.
        Пример лабиринта:
        1 1 1 1 1 1 1
        1 0 0 0 0 0 1
        1 0 1 1 1 0 1
        0 0 0 0 1 0 2
        1 1 0 0 1 1 1
        1 1 1 1 1 1 1
        1 1 1 1 1 1 1
        Напишите алгоритм определяющий наличие выхода из лабиринта и выводящий на экран 
        координаты точки выхода если таковые имеются.
        static bool HasExix(int startI, int startJ, int[,] l)
         */

        public static void PrintList (List<int> list)
        {
            foreach (int i in list)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();
        }

        public static void PrintDictionary(Dictionary<int, int> dict) {
            foreach (var i in dict)
            {
                Console.WriteLine($"namber: {i.Key}  fryqency: {i.Value}");
            }
        }
    static void Main(string[] args)
        {
            List<int> ints = new List<int> { 0, 1, 1, -1, 101, 102, 101, 11, 1111, 11 };
            PrintList(ints);
            List<int> onlyUniqNamber = GetOnlyUniqNamberFromList(ints);
            PrintList(onlyUniqNamber);

            Console.WriteLine();
            List<int> ints2 = new List<int> { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 5, 6, 7, 0 };
            PrintList(ints2);
            List<int> listSortFriqyncyGrow = ListSortFriqencyGrow(ints2);
            Console.WriteLine();
            PrintList(listSortFriqyncyGrow);
        }
    }
}