using System.Reflection;

namespace ConsoleApp07
{
    class MyClass1
    {
        int MyField = 3;
        public int MyProperty => MyField;
        public void SayHello() => Console.WriteLine("Говорю: привет!");
        public void SayWords(string s) => Console.WriteLine($"Говорю: {s}.");
        public int IntMethod(int x, int y) => x + y;
        private int MyIntMethod(int x, int y) => x * y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var obj = new object();
            Type type = obj.GetType();

            Console.WriteLine();
            Console.WriteLine(type);
            Console.WriteLine(type.FullName);
            Console.WriteLine();

            Type type2 = typeof(object);
            Console.WriteLine();
            Console.WriteLine(type2);
            Console.WriteLine(type2.FullName);
            Console.WriteLine();


            Tuple<int, string> tuple1 = new Tuple<int, string>(25, "ghjj");
            Type type3 = tuple1.GetType();
            Console.WriteLine();
            Console.WriteLine(type3);
            Console.WriteLine(type3.FullName);
            Console.WriteLine();

            
            Type type4 = typeof(IEnumerable<>);
            Console.WriteLine();
            Console.WriteLine(type4);
            Console.WriteLine(type4.FullName);
            Console.WriteLine();

            Type type5 = typeof(DivideByZeroException);
            Console.WriteLine();
            Console.WriteLine(type5);
            Console.WriteLine(type5?.BaseType);
            Console.WriteLine(type5?.BaseType?.BaseType);
            Console.WriteLine(type5?.BaseType?.BaseType?.BaseType);
            Console.WriteLine(type5?.BaseType?.BaseType?.BaseType?.BaseType);
            Console.WriteLine(type5?.BaseType?.BaseType?.BaseType?.BaseType?.BaseType);
            Console.WriteLine(type5?.BaseType?.BaseType?.BaseType?.BaseType?.BaseType?.BaseType);
            Console.WriteLine();


            Console.WriteLine("Доступ к методам **********************************");
            Console.WriteLine();

            var objMyClass1 = new MyClass1();
            var type6 = typeof(MyClass1);
            Console.WriteLine(type6);
             
            type6.InvokeMember("SayHello", 
                BindingFlags.Instance| BindingFlags.Public| BindingFlags.InvokeMethod, 
                null, 
                objMyClass1, 
                new Object[] { });

            var res2 = type6.InvokeMember("SayWords", 
                BindingFlags.Instance| BindingFlags.Public| BindingFlags.InvokeMethod, 
                null, 
                objMyClass1, 
                new Object[] {"Я тестовое слово!" });
            Console.WriteLine(res2);

            var res3 = type6.InvokeMember("IntMethod",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod,
                null,
                objMyClass1,
                new Object[] {1, 2});
            Console.WriteLine(res3);

            var res4 = type6.InvokeMember("MyIntMethod",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
                null,
                objMyClass1,
                new Object[] {2, 2});
            Console.WriteLine(res4);

            Console.WriteLine("Доступ к полям и свойствам **********************************");
            Console.WriteLine();

            var obj2MyClass1 = new MyClass1();
            var type7 = typeof(MyClass1);
            Console.WriteLine(type6);

            PropertyInfo? propInfo = type7.GetProperty("MyProperty");
            Console.WriteLine(propInfo);

            Console.WriteLine(propInfo?.GetValue(obj2MyClass1));

            Console.WriteLine("Атрибуты **********************************");
            Console.WriteLine();





            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine();
        }
    }
}