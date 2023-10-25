using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static int devideTwoNambers(int n1, int n2)
        {
            int res = n1 / n2;
            return res;
        }
        static void Main(string[] args)
        {
            int res = devideTwoNambers(1, 1);
            Console.WriteLine($" result = {res}"); 

            //if (args.Length > 0)
            //{
            //    string name = args[0];
            //    string message = $"Привет, {name}!";

            //    Console.WriteLine(message);
            //}
            //else 
            //{
            //    Console.WriteLine("Привет!!!");
            //}
        }
    }
}