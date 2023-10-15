namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
            ArrayArray.PrintArrayArray(a);
            Console.WriteLine();

            int[,] b = ArrayArray.SortToMaxArrayArray(a);
            ArrayArray.PrintArrayArray(b);

        }
    }
}