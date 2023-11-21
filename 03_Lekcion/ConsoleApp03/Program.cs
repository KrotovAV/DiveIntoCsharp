using System;
using System.Collections;

namespace ConsoleApp03
{
    internal class Program
    {
        static void PrintBitArray(BitArray bits)
        {
            foreach (var b in bits)
            {
                Console.Write($"{b} ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var bits = new BitArray(8, false);

            PrintBitArray(bits);

            bits.Or(new BitArray(new bool[] {true, false, false, false, false, false, false, false }));
            PrintBitArray(bits);

            Console.WriteLine();
            Console.WriteLine("List *********************");
            Console.WriteLine();

            var l1 = new List<int>();
            var l2 = new List<int>(new int[] {1, 2, 3, 4});
            var l3 = new List<int>(4);

            Console.WriteLine(l1.Capacity);
            Console.WriteLine(l2.Capacity);
            Console.WriteLine(l3.Capacity);

            l1.Add(5);
            Console.WriteLine(l1.Capacity);
            l1.Add(5);
            Console.WriteLine(l1.Capacity);
            l1.Add(5);
            Console.WriteLine(l1.Capacity);
            l1.Add(5);
            Console.WriteLine(l1.Capacity); 
            l1.Add(5);
            Console.WriteLine(l1.Capacity);
            int[] num = new int[] { 1, 2, 3, 4 };
            l1.AddRange(num);
            Console.WriteLine(l1.Count);
            Console.WriteLine(l1.Capacity);

            var strings = l1.ConvertAll<string>(new Converter<int, string>(Convert.ToString));

            foreach(string str in strings)
            {
                Console.WriteLine(str + "*");
            }
            int[] num2 = new int[15];
            l1.CopyTo(2, num2, 1, 4);
            foreach (int n in num2)
            {
                Console.Write(n + "*");
            }

            Console.WriteLine();
            Console.WriteLine("LinkedList *********************");
            Console.WriteLine();


            LinkedList<int> myLL1 = new LinkedList<int>();
            LinkedList<int> myLL2 = new LinkedList<int>(new int[] {1, 2, 3, 4, 5});

            Console.WriteLine(myLL2.First?.Value);
            Console.WriteLine(myLL2.Last?.Value);
            Console.WriteLine();

            var node = myLL2.First;
            while (node != null) 
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }

            myLL2.AddAfter(myLL2.First, 6);
           
            foreach (var n in myLL2)
            {
                Console.Write(n + ", ");
            }
            Console.WriteLine();

            myLL2.AddBefore(myLL2.First, 9);

            foreach (var n in myLL2)
            {
                Console.Write(n + ", ");
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("Dictionary *********************");
            Console.WriteLine();


            List<KeyValuePair<int, int>> kVP = 
                new List<KeyValuePair<int, int>> { new KeyValuePair<int, int>(1, 11), new KeyValuePair<int, int>(2, 22) };

            Dictionary<int, int> d1 = new Dictionary<int, int>();
            Dictionary<int, int> d2 = new Dictionary<int, int>(kVP);
            Dictionary<int, int> d3 = new Dictionary<int, int>(5);

            Console.WriteLine(d2.Count);
            Console.WriteLine(d2[1]);

           var dictKeys = d2.Keys;
            foreach (var key in dictKeys)
            {
                Console.WriteLine(key);
            }

            var dictVal = d2.Values;
            foreach (var val in dictVal)
            {
                Console.WriteLine(val);
            }

            
            d2.Add(3, 33);
            d2[4] = 44;

            foreach (var key in dictKeys)
            {
                Console.WriteLine($"{key} - {d2[key]},");
            }

            //d2.Add(3, 33);  - вызовет ошибку

            Dictionary<int, int>.Enumerator enumerator = d2.GetEnumerator();
            
            while (enumerator.MoveNext()) 
            {
                Console.WriteLine(enumerator.Current);
                int key = enumerator.Current.Key;
                int val = enumerator.Current.Value;
            }



            Console.WriteLine();
            Console.WriteLine("LINQ ********************");
            Console.WriteLine();

            string[] names = new string[] { "Анна", "Алена", "Алексей", "Владимир", "Виталий", "Виктор", "Георгий" };
            IEnumerable<string> namesA = from name in names
                                         where name.StartsWith('А')
                                         select name;

            foreach (var n in namesA)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();

            IEnumerable<string> namesB = names.Where(n => n.StartsWith('В'));
            foreach (var n in namesB)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("********************");
            Console.WriteLine();
        }
    }
}