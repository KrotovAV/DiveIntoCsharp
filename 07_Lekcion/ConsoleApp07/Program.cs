namespace ConsoleApp07
{
    internal class Program
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
        }
    }
}