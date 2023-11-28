using System.Text.Json;
using System.Text;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ConsoleApp09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Напишите приложение, конвертирующее произвольный JSON в XML.
             */

            Person person = new Person { Name = "Slava", Surname = "Petrov", Age = 22, Hobbies = new List<Hobby> { Hobby.Fishing, Hobby.Painting } };
            //Console.WriteLine(person);
            Console.WriteLine();

            string jsonPerson1 = """
                {"Name":"Dima","Surname":"Petrov","Age":22,"Hobbies":[1,0]}
                """;
            string jsonPerson2 = "";
            string jsonPerson3 = string.Empty;
            string jsonPerson4 = """
              ame":"Dima","Surname":"Petrov","Age":22,"Hobbies":[1,0]}
            """;

            string[] strArr = new string[] {jsonPerson1, jsonPerson2, jsonPerson3, jsonPerson4 };
            foreach (string str in strArr)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine($"Исходная строка: {str}");
                string? xmlPerson = Converter.ConvertJsonToXML<Person>(str);
                Console.WriteLine($"XML строка: {xmlPerson}");
                Console.WriteLine();
                
            }
        }
    }
}