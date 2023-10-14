using System;

namespace test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string name = args[0];
                string message = $"Привет, {name}";
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Hello, World!");
            }
        }
    }
}