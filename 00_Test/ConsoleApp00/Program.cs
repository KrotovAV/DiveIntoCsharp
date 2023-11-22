using System.Collections.Generic;

namespace ConsoleApp00
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
         

            IUser<int> user1 = new User<int>(6789);
            Console.WriteLine(user1.Id);    // 6789

            IUser<string> user2 = new User<string>("12345");
            Console.WriteLine(user2.Id);    // 12345
        }
    }
}