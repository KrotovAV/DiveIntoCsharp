﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

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
            Console.WriteLine("Stream *********************");
            Console.WriteLine();

            string current2 = Directory.GetCurrentDirectory();
            DirectoryInfo? projRoot = GetProjectRoot(current2);
            
            if(projRoot == null)
            {
                Console.WriteLine("Не могу найти каталог проекта");
            }
            Console.WriteLine(projRoot);

            var pathToProgram = Path.Combine(projRoot.FullName, "Program.cs");
            //Console.WriteLine(pathToProgramm);
            if (!Path.Exists(pathToProgram))
            {
                Console.WriteLine($"{pathToProgram} не найден. Завершаем работу");
                return;
            }

            using(FileStream fStream = new FileStream(pathToProgram, FileMode.Open))
            {
                Console.WriteLine($"Файл {pathToProgram} открыт");

                byte[] bytes = new byte[fStream.Length];
                var read = fStream.Read(bytes, 0, bytes.Length);

                if(read == bytes.Length)
                {
                    var str = Encoding.Default.GetString(bytes);
                    Console.WriteLine(str);
                }
            }

            var pathNew = Path.ChangeExtension(pathToProgram, ".bak");
            using (FileStream fStream2 = new FileStream(pathToProgram, FileMode.Open))
            {
                using (FileStream fStreamOut2 = new FileStream(pathNew, FileMode.Create, FileAccess.Write))
                {
                    //int b = 0;
                    //while((b = fStream2.ReadByte()) >= 0)
                    //{
                    //    fStreamOut2.WriteByte((byte)b);
                    //}

                    //или проще

                    fStream2.CopyTo(fStreamOut2);
                    fStreamOut2.Flush();
                }
            }









                Console.WriteLine();
            Console.WriteLine("*********************");
            Console.WriteLine();
        }
    }
}