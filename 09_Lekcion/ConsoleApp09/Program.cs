using System;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace ConsoleApp09
{
    public class Occupacion
    {
        public string Company;
        public string Position;
    }

    public enum Hobby
    {
        Painting,
        Fishing,
        Sport
    }
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public List<Hobby> Hobbies { get; set; }
        public override string ToString()
        {
            return $"Имя: {Name}, " +
                $"Фамилия: {Surname}, " +
                $"Возраст: {Age}, " +
                $"Хобби: {string.Join(", ",Hobbies)}"
                .ToString();
        }
    }
        public class MyClass
    {
        private int _field1 = 10;
        private int _field2 = 20;

        public int Field3 = 30;
        public int Field4 = 40;

        public override string ToString()
        {
            return $"_field1 = {_field1}, _field2 = {_field2}, Field3 = {Field3}, Field4 = {Field4}";
        }
    }

    public class MySettings
    {
        public string Setting1 = " ";
        public string Setting2 = " ";
        public string Setting3 = " ";

        public override string ToString()
        {
            return $"Setting1 = {Setting1}, Setting2 = {Setting2}, Setting3 = {Setting3}";
        }
    }
    internal class Program
    {
        static void SaveSettings(MySettings settings)
        {
            string path = "mySettings.xml";
            var serializer = new XmlSerializer(settings.GetType());
            using (var stream = File.OpenWrite(path))
            {
                serializer.Serialize(stream, settings);
            }
        }

        static MySettings? LoadSettings()
        {
            string path = "mySettings.xml";
            var serializer = new XmlSerializer(typeof(MySettings));
            if (Path.Exists(path))
            {
                using (var stream = File.OpenRead(path))
                {
                    return (MySettings?)serializer.Deserialize(stream);
                }
            }
            else
            {
                return null;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Сериализация потока xml--------------------------------------------");
            Console.WriteLine();


            var serializer = new XmlSerializer(typeof(MyClass));

            MyClass myClass1 = new MyClass();
            serializer.Serialize(Console.Out, myClass1);

            string str = """
                <MyClass>
                    <Field3>300</Field3>
                    <Field4>400</Field4>
                </MyClass>
                """;

            Console.WriteLine();
            Console.WriteLine();

            var obj = (MyClass?)serializer.Deserialize(new StringReader(str));
            if (obj != null)
            {
                Console.WriteLine("Объект десериализован");
                Console.WriteLine(obj);
            }

            Console.WriteLine();
            Console.WriteLine("Десериализация потока xml--------------------------------------------");
            Console.WriteLine();


            var settings = LoadSettings();

            if (settings == null)
            {
                Console.WriteLine("Загружены настройки по умолчанию");
                settings = new MySettings { Setting1 = "Off", Setting2 = "off", Setting3 = "000" };
                SaveSettings(settings);
            }
            else
                Console.WriteLine("Настройки успешно загружены");

            Console.WriteLine("Действующие настройки: " + settings.ToString());

            
            settings.Setting1 = "on";
            settings.Setting2 = "on";
            settings.Setting3 = "001";

            SaveSettings(settings);

            Console.WriteLine();
            Console.WriteLine(settings);

            Console.WriteLine();
            Console.WriteLine("Json сериализация и десериализация ---------------------------------");
            Console.WriteLine();

            Person person1 = new Person { Name = "Slava", Surname = "Petrov", Age = 22, Hobbies = new List<Hobby> { Hobby.Fishing, Hobby.Painting } };

            Console.WriteLine(person1);
            string jsonPerson1 = JsonSerializer.Serialize(person1);

            Console.WriteLine("JSON:" + jsonPerson1);
            Console.WriteLine();


            Person? newPerson = JsonSerializer.Deserialize<Person>(jsonPerson1);
            Console.WriteLine(newPerson);

            Console.WriteLine();
            Console.WriteLine("Json сериализация и десериализация потоков ---------------------------");
            Console.WriteLine();

            Person person2 = new Person { Name = "Dima", Surname = "Petrov", Age = 22, Hobbies = new List<Hobby> { Hobby.Fishing, Hobby.Painting } };

            Console.WriteLine(person2);

            using (var stream  = new MemoryStream())
            {
                JsonSerializer.Serialize(stream, person2, person2.GetType());
                string jsonPerson2 = Encoding.UTF8.GetString(stream.ToArray());
                Console.WriteLine("JSON:" + jsonPerson2);
            }

            Console.WriteLine();

            string jsonPerson22 = """
                {"Name":"Dima","Surname":"Petrov","Age":22,"Hobbies":[1,0]}
                """;

            using (var stream2 = new MemoryStream(Encoding.UTF8.GetBytes(jsonPerson22)))
            {
                var newPerson2 = (Person?)JsonSerializer.Deserialize(stream2, typeof(Person));
                Console.WriteLine(newPerson2);
            }


            Console.WriteLine();
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine();
        }
    }
}