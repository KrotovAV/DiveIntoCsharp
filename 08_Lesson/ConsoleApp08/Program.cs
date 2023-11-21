using System.Diagnostics;
using System.IO;

namespace ConsoleApp08
{
    internal class Program
    {
        //Задача 1
        public static void MyCopyFile(string str1, string str2)
        {
            if (!Path.Exists(str1))
            {
                Console.WriteLine("Файла не существует");
                return;
            }
            
            if (Path.GetFileName(str2) != null)
            {
                str2 = Path.Combine(str2, Path.GetFileName(str1));
                //Console.WriteLine($"Файл будет скопирован в {str2}");
            }
            using (StreamReader sr = new StreamReader(str1))
            {
                using (StreamWriter sw = new StreamWriter(str2))
                {
                    sw.WriteLine(sr.ReadToEnd());
                    Console.WriteLine("Файл скопирован");
                }
            }
            
        }
        // задача 2
        public static void FindFileInDirectory(string directory, string fileName)
        {
            var dirs = Directory.EnumerateDirectories(directory);
            var files = Directory.EnumerateFiles(directory);
            foreach (var file in files)
            {
                if (file.Contains(fileName))
                {
                    Console.WriteLine($"файл {fileName} находится в директории {directory})");
                    Console.WriteLine();
                    break;
                }
            }
            foreach(var dir in dirs)
            {
                FindFileInDirectory(dir, fileName);
            }
        }

        //задача 3
        public static void FinfWordInFile(string path, string findWord)
        {
            if (!Path.Exists(path))
            {
                Console.WriteLine("Файла не существует!!!!");
                return;
            }
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream) 
                {
                    string val = sr.ReadLine();
                    if (val.Contains(findWord))
                    {
                        Console.WriteLine(val);
                    }
                }
            }
        }
        
        //задача 4
        public static void ChangeFileContein(string path, string findWord)
        {          
            using (File.Create(path));
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /* Задача 1
            Напишите консольную утилиту для копирования файлов 
            Пример запуска: utility.exe file1.txt file2.txt
            */
            string wayFile1 = "D:\\GeekBrains\\Exampl.txt";
            string wayFile2 = "D:\\";
            //MyCopyFile(wayFile1, wayFile2);



            /* Задача 2
            Напишите утилиту рекурсивного поиска файлов в заданном каталоге и подкаталогах
            */
            string wayFile21 = "Exampl.txt";
            string wayDir2 = "D:\\GeekBrains\\";
            //FindFileInDirectory(wayDir2, wayFile21);



            /* Задача 3
            Напишите утилиту читающую тестовый файл и выводящую на экран строки 
            содержащие искомое слово.
            */
            string wayFile31 = "D:\\GeekBrains\\Exampl.txt";
            string wordToFind2 = "third";
            FinfWordInFile(wayFile31, wordToFind2);

            /* Задача 4
            Считать данные из файла, изменить их и сорхранить изменения
            */
            string wayFile41 = "D:\\GeekBrains\\Exampl.txt";
            string wordToChange = "five";
            ChangeFileContein(wayFile41, wordToChange);

        }
    }
}