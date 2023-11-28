using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp09
{
    public static class Converter
    {
        public static string ConvertJsonToXML<T>(string jsonStringObject)
        {
            string xmlStringObject = string.Empty;
            
            if (jsonStringObject == null || jsonStringObject == string.Empty)
            {
                Console.WriteLine("Конвертация не возможна, т.к. исходная строка не существуют или является пустой");
                return xmlStringObject;
            }
            else
            {
                T ? newObject;
                XmlSerializer serializer;
                using (MemoryStream stream1 = new MemoryStream(Encoding.UTF8.GetBytes(jsonStringObject)))
                {
                    try
                    {
                        newObject = (T?)JsonSerializer.Deserialize(stream1, typeof(T));
                        //Console.WriteLine(newObject);
                        serializer = new XmlSerializer(newObject.GetType());
                    }
                    catch
                    {
                        Console.WriteLine("Конвертация не возможна, исходная строка повреждена, \nили данные из неё не корректны, \nили данных не достатчоно для конвертации.");
                        return xmlStringObject;
                    }
                }

                //serializer = new XmlSerializer(newObject.GetType());
                using (MemoryStream stream2 = new MemoryStream())
                {
                    try
                    {
                        serializer.Serialize(stream2, newObject);
                        stream2.Seek(0, SeekOrigin.Begin);
                        StreamReader reader = new StreamReader(stream2, Encoding.UTF8);
                        xmlStringObject = reader.ReadToEnd();
                        //Console.WriteLine(xmlStringObject);
                    }
                    catch
                    {
                        Console.WriteLine("Конвертация не возможна, исходная строка повреждена, \nили данные из неё не корректны, \nили данных не достатчоно для конвертации.");
                        return xmlStringObject;
                    }
                }
                return xmlStringObject;
            }
        }
    }
}
