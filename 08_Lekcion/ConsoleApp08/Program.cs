using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp08
{
    internal class Program
    {
        static DirectoryInfo? GetProjectRoot(string current)
        {
            Stack<string> names = new Stack<string>(new string[] { "bin", "Debug", "net7.0" });
            DirectoryInfo? dI = new DirectoryInfo(current);
            while (names.Count > 0)
            {
                string expected = names.Pop();
                if (dI.Name == expected)
                {
                    dI = dI.Parent;
                }
                else
                {
                    return null;
                }
            }
            return dI;
        }
        static bool ContainExtensions(DirectoryInfo dir, string[] extensions)
        {
            HashSet<string> hashSet = new HashSet<string>(extensions);
            foreach( var f in dir.GetFiles())
            {
                hashSet.Remove(f.Extension);
            }
            return hashSet.Count == 0;
        }
        static void PrintDirictoryInfo(DirectoryInfo dir)
        {
            foreach (var f in dir.GetDirectories())
            {
                Console.WriteLine($"[{f.Name}]".PadRight(30) +$" <{CalculeteDirectorySize(f)}>");
            }
            foreach (var f in dir.GetFiles())
            {
                Console.WriteLine($"{f.Name.PadRight(30)} <{f.Length}>");
            }
        }
        static long CalculeteDirectorySize(DirectoryInfo dir)
        {
            long size = 0;
            foreach (var d in dir.GetDirectories())
            {
                size += CalculeteDirectorySize(d);
            }
            foreach (var f in dir.GetFiles())
            {
                size += f.Length;
            }
            return size;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine();
            Console.WriteLine("*********************");
            Console.WriteLine();

            string current = Directory.GetCurrentDirectory();
            var parentDir = Directory.GetParent(current);
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(parentDir);
            Console.WriteLine();
            Console.WriteLine("***");
            var res = GetProjectRoot(current);
            if (res == null)
            {
                Console.WriteLine("Не удалось найти каталог проекта");
                return;
            }
            //Console.WriteLine(res);
            foreach(var f in res.EnumerateFiles())
            {
                Console.WriteLine(f);
            }
            //Console.WriteLine(GetProjectRoot(current));

            if(ContainExtensions(res, new string[] {".cs", ".csproj" }))
            {
                Console.WriteLine("Найден");
            }

            
            Console.WriteLine();
            Console.WriteLine("***");
            PrintDirictoryInfo(res);
            Console.WriteLine(CalculeteDirectorySize(res));



            Directory.CreateDirectory(current+"/1");

            Directory.Delete(current + "/1");

            Console.WriteLine(Directory.GetDirectoryRoot(current));



            Console.WriteLine();
            Console.WriteLine("*********************");
            Console.WriteLine();
        }
    }
}