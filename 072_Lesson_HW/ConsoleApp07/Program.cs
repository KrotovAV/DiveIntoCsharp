using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApp07
{
    internal class Program
    {
        public static void PrintObject(object nameObj)
        {
            if (nameObj != null)
            {
                Type varType = nameObj.GetType();
                PropertyInfo[] varProp = varType.GetProperties();
                Console.WriteLine(varType.Name);

                foreach (var item in varProp)
                {
                    string timeString;
                    var varGetValue = item.GetValue(nameObj);
                    if (item.PropertyType == typeof(char[]))
                    {
                        timeString = new String(varGetValue as char[]);
                    }
                    else
                    {
                        timeString = varGetValue.ToString();
                    }
                    Console.WriteLine(item.Name + ":" + timeString);
                }
            }
            else 
            {
                Console.WriteLine("Передан объект равный нулю.");
            }
        }
        public static TestClass CreateTestClassInstance(
            int i,
            int a,
            string s,
            decimal d,
            char[] c,
            char[] cc)
        {
            var testClassType = typeof(TestClass);

            var testClass = Activator.CreateInstance(testClassType) as TestClass;

            var testClassTwo = Activator.CreateInstance(
                testClassType,
                new object[] { i });

            var testClassThird = Activator.CreateInstance(
                testClassType,
                new object[] { i, a, s, d, c, cc });
            return testClassThird as TestClass;
        }
        public static string ObjectToString(object obj)
        {
            StringBuilder stringbuilder = new StringBuilder();
            var varType = obj.GetType();
            stringbuilder.Append(varType.ToString() + "\n");
            stringbuilder.Append(varType.Assembly + "\n");
            stringbuilder.Append(varType.Name + "\n");
            //var varProp2 = varType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            var varProp = varType.GetProperties();
            //var varProp = varType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance || 
            //     BindingFlags.Public | BindingFlags.Instance);

            foreach (var item in varProp)
            {
                var varGetValue = item.GetValue(obj);
                //if(item.GetCustomAttribute<DontSaveAttribute>() != null)
                //{
                //    Console.WriteLine("zzz - DontSaveAttribute " + item.Name);
                //    continue;
                //}
                if (item.GetCustomAttribute<CustomNameAttribute>() != null)
                {
                    CustomNameAttribute? myAttr = item.GetCustomAttribute<CustomNameAttribute>();
                    string timeName = myAttr.CustomFieldName;
                    //Console.WriteLine("zzz - CustomNameAttribute " + item.Name);
                    stringbuilder.Append(timeName + ":");
                }
                else
                {
                    stringbuilder.Append(item.Name + ":");
                }
                if (item.PropertyType == typeof(char[]))
                {
                    stringbuilder.Append(new String(varGetValue as char[]) + "\n");
                }
                else
                {
                    stringbuilder.Append(varGetValue + "\n");
                }
            }
            return stringbuilder.ToString();
        }

        public static object StringToObject(String endString)
        {
            string[] stringArr = endString.Split("\n");
            var varObj = Activator.CreateInstance(stringArr[1], stringArr[0])?.Unwrap();
            Type type = varObj.GetType();
            var varProp = type.GetProperties();

            if (stringArr.Count() > 1 && varObj != null)
            {
                for (int i = 3; i < stringArr.Count() - 1; i++)
                {
                    var fiedVal = stringArr[i].Split(':');
                    Console.WriteLine($"{fiedVal[0]}:{fiedVal[1]}");
                    var property = type.GetProperty(fiedVal[0]);
                    if (property == null)
                    {
                        PropertyInfo[] properties = type.GetProperties();
                        foreach (PropertyInfo prop in properties)
                        {
                            var attributesI = prop.GetCustomAttributes(false);
                            foreach (var attribute in attributesI)
                            {
                                if (attribute is CustomNameAttribute)
                                {
                                    property = type.GetProperty(prop.Name);
                                    property.SetValue(varObj, int.Parse(fiedVal[1]));
                                }
                            }
                        }
                    }
                    if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(varObj, int.Parse(fiedVal[1]));
                    }

                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(varObj, fiedVal[1]);
                    }

                    if (property.PropertyType == typeof(decimal))
                    {
                        property.SetValue(varObj, decimal.Parse(fiedVal[1]));
                    }

                    if (property.PropertyType == typeof(char[]))
                    {
                        property.SetValue(varObj, fiedVal[1].ToCharArray());
                    }

                }
            }
            return varObj;
        }



        static void Main(string[] args)
        {
            
            /*Задача 1
           Создать методы создающий этот класс вызывая один из его конструкторов
           (по одному конструктору на метод). Задача не очень сложна и служит
           больше для разогрева перед следующей задачей.
           */
            
            var v = CreateTestClassInstance(1, 2, "3", 4m, new char[] { '5', '6', '7' }, new char[] { '8', '9', '0' });
            
            Console.WriteLine();
            Console.WriteLine(nameof(v));
            PrintObject(v);
            Console.WriteLine("-----------------------------");

            /*задача 2
            Напишите 2 метода использующие рефлексию
            1 - сохраняет информацию о классе в строку
            2 - позволяет восстановить класс из строки с информацией о методе
            В качестве примере класса используйте класс TestClass.
            Шаблоны методов для реализации:
            static object StringToObject(string s) { }
            static string ObjectToString(object o) { }

            Пример того как мог быть выглядеть сохраненный в строку объект: 
            “TestClass, test2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:TestClass|I:1|S:STR|D:2.0|”

            */
            
            string str = ObjectToString(v);
            Console.WriteLine(str);

            object? obj2 = StringToObject(str) as TestClass;
            Console.WriteLine("-----------------------------");

            /*
            Разработайте атрибут позволяющий методу ObjectToString сохранять 
            поля классов с использованием произвольного имени.

            Метод StringToObject должен также уметь работать с этим атрибутом 
            для записи значение в свойство по имени его атрибута.
            [CustomName(“CustomFieldName”)]
            public int I = 0.

            Если использовать формат строки с данными использованной нами для предыдущего
            примера то пара ключ значение для свойства I выглядела бы CustomFieldName:0

            Подсказка:
            Если GetProperty(propertyName) вернул null то очевидно свойства с таким 
            именем нет и возможно имя является алиасом заданным с помощью CustomName. 
            Возможно, если перебрать все поля с таким атрибутом то для одного из них 
            propertyName = совпадает с таковым заданным атрибутом.
             */
            
            Console.WriteLine();
            Console.WriteLine(nameof(obj2));
            PrintObject(obj2);


        }
    }
}