using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp08
{
    internal class Program
    {
        public static void FindFileInDirectory(string directory, string fileName, string findText)
        {
            var dirs = Directory.EnumerateDirectories(directory);
            var files = Directory.EnumerateFiles(directory);
            foreach (var file in files)
            {
                if (file.Contains(fileName))
                {
                    FinfWordInFile(file, findText);
                    //Console.WriteLine($"файл {file} находится в директории {directory})");
                }
            }
            foreach (var dir in dirs)
            {
                FindFileInDirectory(dir, fileName, findText);
            }
        }

        public static void FinfWordInFile(string path, string findWord)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string val = sr.ReadLine();
                    if (val.Contains(findWord))
                    {
                        Console.WriteLine($"Путь: {path}, строка с искомым текстом: {val}");
                    }
                }
            }
        }
        public static string InputDirToFind()
        {
            bool valid = false;
            string inputDir;
            do
            {
                Console.WriteLine("Укажите диреторию для поиска ");
                inputDir = Console.ReadLine();
                valid = Directory.Exists(inputDir);
                if(valid == false)
                    Console.WriteLine("Директория не существует или произошла ошибка ввода, \nПопробуйте ещё раз ");
            } while(!valid);
            return inputDir;
        }
        public static string InputFileToFind()
        {
            bool valid = false;
            string inputFile;
            HashSet<string> formats = new HashSet<string>() { ".txt", ".cs",".java", ".doc", ".tex", ".text", ".pdf", ".log", ".apt", ".ttf", ".err", ".sub", ".djvu", ".odt", ".rtf" };
            do
            {
                Console.WriteLine("Укажите тип файла для поиска ");
                inputFile = Console.ReadLine();
                valid = formats.Contains(inputFile);
                if (valid == false)
                    Console.WriteLine("Тип файла с таким расширением не существует или произошла ошибка ввода, \nПопробуйте ещё раз ");
            } while (!valid);
            return inputFile;
        }
        public static string InputTextToFind()
        {
            bool valid = false;
            string inputText;
            do
            {
                Console.WriteLine("Введите текст для поиска ");
                inputText = Console.ReadLine();
                if (inputText == "")
                {
                    Console.WriteLine("Текст не введён или произошла ошибка ввода, \nПопробуйте ещё раз ");
                }
                else
                {
                    valid = true;
                }
            } while (!valid);
            return inputText;
        }

        public static void FinfTextInFileToFind()
        {
            string dir = InputDirToFind();

            if (!Path.Exists(dir))
            {
                Console.WriteLine("Указанный путь не существует!!!!");
                return;
            }
            string typeFile = InputFileToFind();
            string findText = InputTextToFind();
            FindFileInDirectory(dir, typeFile, findText);

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /*
             * Объедините две предыдущих работы (практические работы 2 и 3): поиск файла 
             * и поиск текста в файле написав утилиту которая ищет файлы определенного 
             * расширения с указанным текстом. Рекурсивно. Пример вызова 
             * утилиты: utility.exe txt текст.
             */


            FinfTextInFileToFind();
        }
    }
}