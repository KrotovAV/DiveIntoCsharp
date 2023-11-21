using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp07
{
    internal class Program
    {
        //public static void CreateTestClassInstance(
        //int i,
        //string s,
        //decimal d,
        //char[] c)
        //{
        //    var testClassType = typeof(TestClass);
        //    var testClass = Activator.CreateInstance(testClassType) as TestClass;

        //    var testClassTwo = Activator.CreateInstance(
        //        testClassType,
        //        new object[] { i });

        //    var testClassThird = Activator.CreateInstance(
        //        testClassType,
        //        new object[] { i, s, d, c });

        //}
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

        //“TestClass, test2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:TestClass|I:1|S:STR|D:2.0|”
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
                
                stringbuilder.Append(item.Name + ":");
                
                if (item.PropertyType == typeof(char[]))
                {
                    stringbuilder.Append(new String (varGetValue as char[]) + "\n");
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

            
            //в этом методе вместо имени и свойства - получить атрибуты
            return endString;
        }
            static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /*Задача 1
            Создать методы создающий этот класс вызывая один из его конструкторов
            (по одному конструктору на метод). Задача не очень сложна и служит
            больше для разогрева перед следующей задачей.
            */

            
            var v = CreateTestClassInstance(1, 2, "2", 3m, new char[] { '4', '3', '2' }, new char[] { '1', '2', '3' });

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

            object obj2 = StringToObject(str);
        }
    }
}