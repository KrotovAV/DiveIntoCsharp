using System.Drawing;

namespace ConsoleApp002
{
    enum Colors
    {
        Red,
        Green,
        Blue,
        Yellow = 22
    }

    public struct Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Colors.Blue);
            Console.WriteLine((int)Colors.Blue);
            Console.WriteLine((Colors)1);

            Point2D Point = new Point2D();
            Point.X = 100;
            Point.Y = 100;
            
            Console.WriteLine(Point.ToString());

            var tuple1 = (10, 23.4); //Определен кортеж tuple1 с двумя значениями 10 и 23.4
            Console.WriteLine(tuple1);
            Console.WriteLine(tuple1.Item1);
            Console.WriteLine(tuple1.Item2);

            (string, int) tuple3 = ("Coin", 25);
            Console.WriteLine(tuple3.Item1);
            Console.WriteLine(tuple3.Item2);

            (int a, int b, int c) tuple2 = (11, 33, 20);                      //Определение кортежа с целочисленными значениями
            Console.WriteLine(tuple2.a);    //Вывод на консоль 11
            tuple2.b *= 2;                 //Умножение второго значения на 2
            Console.WriteLine(tuple2.b);
            Console.WriteLine(tuple2.c);

            int? abc = null;
            Console.WriteLine(abc);


            byte b = 20;
            int i = 10;
            i = b;
            Console.WriteLine(i);

            int ii = 256;
            byte bb = 20;
            bb = (byte)ii;
            Console.WriteLine(bb);

            object obj1 = new object();
            object obj2 = new object();

            bool bo = obj1.Equals(obj2);
            Console.WriteLine(bo);

            string st = "text";
            char[] ch = st.ToCharArray();
            foreach (char c in ch)
            {
                Console.WriteLine(c);
            }


        }
    }
}