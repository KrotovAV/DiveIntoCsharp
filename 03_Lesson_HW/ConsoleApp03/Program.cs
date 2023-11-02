using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp03
{
    internal class Program
    {
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
        Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте:
        static bool HasExix(int startI, int startJ, int[,] l)
         */

        static bool CheckStartPointInLabirynth(Point start, int[,] l)
        {
            bool exit = false;
            if(start.x > l.GetLength(0) && start.y > l.GetLength(1))
            {
                exit = true;
            }
            return exit;
        }
        static bool CheckStartPointIsNotWall(Point start, int[,] l)
        {
            bool exit = false;
            if (l[start.x, start.y] == 1)
            {
                exit = true;
            }
            return exit;
        }

        static bool CheckEndPointInLabirynth(Point start, int[,] l)
        {
            bool exit = false;
            if (start.x == 0 || start.x == l.GetLength(0) || 
                start.y == 0 || start.y == l.GetLength(1)) exit = true;
            return exit;
        }

        static int[,] Convert2ToZeroInLabirynth(int[,] l)
        {
            for (int i = 0; i < l.GetLength(0); i++)
            {
                if (l[0, i] == 2)
                {
                    l[0, i] = 0;
                }
            }

            for (int i = 1; i < l.GetLength(1); i++)
            {
                if (l[i, 0] == 2)
                {
                    l[i, 0] = 0;
                }
            }

            for (int i = 1; i < l.GetLength(0); i++)
            {
                if (l[l.GetLength(1) - 1, i] == 2)
                {
                    l[l.GetLength(1) - 1, i] = 0;
                }
            }

            for (int i = 1; i < l.GetLength(1) - 1; i++)
            {
                if (l[i, l.GetLength(1) - 1] == 2)
                {
                    l[i, l.GetLength(1) - 1] = 0;
                }
            }
            return l;
        }

        static List<Point> CheckCountOfInputs(int[,] l)
        {
            List<Point>enteranse = new List<Point>();
            for (int i = 0; i < l.GetLength(0); i ++)
            {
                if (l[0, i] == 0)
                { 
                    enteranse.Add(new Point(0, i));
                }
            }

            for (int i = 1; i < l.GetLength(1); i++)
            {
                if (l[i, 0] == 0)
                {
                    enteranse.Add(new Point(i, 0));
                }
            }

            for (int i = 1; i < l.GetLength(0); i++)
            {
                if (l[l.GetLength(1)-1, i] == 0)
                {
                    enteranse.Add(new Point(l.GetLength(0) - 1, i));
                }
            }

            for (int i = 1; i < l.GetLength(1)-1; i++)
            {
                if (l[i, l.GetLength(1) - 1] == 0)
                {
                    enteranse.Add(new Point(i, l.GetLength(1) - 1));
                }
            }
            return enteranse;
        }
        public static void PrintStack(Stack<Point> stack)
        {
            Console.Write("Stack: [");
            foreach (Point p in stack)
            {
                Console.Write(p +"; ");
            }
            Console.WriteLine("]");
            Console.WriteLine();
        }
        public static void PrintQueue(Queue<Point> queue)
        {
            Console.Write("Queue: [");
            foreach (Point p in queue)
            {
                Console.Write(p + "; ");
            }
            Console.WriteLine("]");
            Console.WriteLine();
        }
        public static void PrintPointList(List<Point> list)
        {
            foreach (Point i in list)
            {
                Console.Write(i + "; ");
            }
            Console.WriteLine();
        }
        public static void PrintLabirynthNam(int[,] l)
        {
            for (int i = 0; i < l.GetLength(0); i++)
            {
                for (int j = 0; j < l.GetLength(1); j++)
                {
                    Console.Write(l[i, j] + " ");
                }
                Console.WriteLine();
            }
            
        }
        public static void PrintLabirynth(int[,] l, Point start)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 2*l.GetLength(0) + 2));
            for (int i = 0; i < l.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < l.GetLength(1); j++)
                {
                    
                    if (l[i, j] == 0)
                    {
                        if (i == start.x && j == start.y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("# ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    else 
                    {
                        if (l[i, j] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("* ");
                            Console.ResetColor();
                        }
                        else
                        Console.Write("X ");
                    }
                    
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 2 * l.GetLength(0) + 2));
        }
        public static void Steps(Point start, int[,] l, List<Point> enteranse)
        {
            Queue<Point> stapWay = new Queue<Point>();
            Queue<Point> stapWayHistory = new Queue<Point>();
            stapWay.Enqueue(start);

            while (stapWay.Count > 0)
            {
                Point point = stapWay.Dequeue();

                if (point.y - 1 >= 0 && l[point.x, point.y - 1] == 0 && point.way != "Right")
                {
                    point.y = point.y - 1;
                    point.way = "Left";
                    if (!stapWayHistory.Contains(point))
                    {
                        stapWayHistory.Enqueue(point);
                        stapWay.Enqueue(point);
                    }
                    //PrintLabirynth(l, point);
                }

                if (point.x - 1 >= 0 && l[point.x - 1, point.y] == 0 && point.way != "Down")
                {
                    point.x = point.x - 1;
                    point.way = "Up";
                    if (!stapWayHistory.Contains(point))
                    {
                        stapWayHistory.Enqueue(point);
                        stapWay.Enqueue(point);
                    }
                    //PrintLabirynth(l, point);
                }

                if (point.y + 1 < l.GetLength(1) && l[point.x, point.y + 1] == 0 && point.way != "Left")
                {
                    point.y = point.y + 1;
                    point.way = "Right";
                    if (!stapWayHistory.Contains(point))
                    {
                        stapWayHistory.Enqueue(point);
                        stapWay.Enqueue(point);
                    }
                    //PrintLabirynth(l, point);
                }

                if (point.x + 1 < l.GetLength(0) && l[point.x + 1, point.y] == 0 && point.way != "Up")
                {
                    point.x = point.x + 1;
                    point.way = "Down";
                    if (!stapWayHistory.Contains(point))
                    {
                        stapWayHistory.Enqueue(point);
                        stapWay.Enqueue(point);
                    }
                    //PrintLabirynth(l, point);
                }

                foreach (Point p in stapWay)
                {
                    foreach (Point p2 in enteranse)
                    {
                        if (p.x.Equals(p2.x) && (p.y.Equals(p2.y)))
                        {
                            Console.WriteLine($"Выход найден! - {p}");
                            return;
                        }
                    }
                }

                //PrintQueue(stapWay);

                if (stapWay.Count == 0)
                {
                    Console.WriteLine("Выхода нет!!");
                }
            }
        }
        public static void HasExitАFromLabirynth(int[,] l, Point start)
        {
            if (CheckStartPointInLabirynth(start, l))
            {
                Console.WriteLine("Точка старта находится за пределами лабиринта!");
                return;
            }

            if (CheckStartPointIsNotWall(start, l))
            {
                Console.WriteLine("Точка старта находится в стене!");
                return;
            }

            if (CheckEndPointInLabirynth(start, l))
            {
                Console.WriteLine("Точка старта находится на выходе!");
                return;
            }

            List<Point> enteranse = CheckCountOfInputs(l);

            if (enteranse.Count == 0)
            {
                Console.WriteLine("НЕ существует выходов из лабиринта!");
                return;
            }

            Steps(start, l, enteranse);
            
        }

        public static void CheckExitsFromLabirynth(int[,] l, Point reversStop)
        {
            List<Point> list = CheckCountOfInputs(l);
            PrintPointList(list);
            
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Check {i+1} point - {list[i]}");
                PrintLabirynth(l, list[i]);
                Steps(list[i], l, new List<Point>() {reversStop});
            }
        }

            static void Main(string[] args)
        {
            /*
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 1, 1, 1, 1, 1, 1 }
             */

            int[,] labirynth1 = new int[,]
                    {
                    {1, 1, 1, 0, 1, 1, 1 },
                    {1, 0, 0, 0, 0, 0, 1 },
                    {1, 0, 1, 1, 1, 0, 1 },
                    {1, 0, 0, 0, 1, 0, 1 },
                    {1, 1, 0, 0, 1, 0, 1 },
                    {1, 1, 1, 0, 1, 0, 0 },
                    {1, 1, 1, 0, 1, 1, 1 }
                    };

            Point start = new Point(3, 3);

            PrintLabirynth(labirynth1, start);

            HasExitАFromLabirynth(labirynth1, start);

            Console.WriteLine("---------------------");
            Console.WriteLine();
            CheckExitsFromLabirynth(labirynth1, start);
        }
    }
}