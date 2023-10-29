namespace ConsoleApp02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Габиль, рашение благополучно нашёл в нашей методичке на 29 странице.
            //Ну и переписал сюда
            var a = new Bits(0);
            for (int i =0; i <= 7; i++)
            {
                if (i%2 == 0)
                    a[i] = true;               
            }
            Console.WriteLine(a.Value.ToString());
            for (int i = 7; i >= 0; i--)
            {
                Console.WriteLine(a[i] + " ");
            }

            var bits = new Bits(10);
            Console.WriteLine("Type of bits - " + bits.GetType());
            byte b = bits;
            Console.WriteLine("Type of b - " + b.GetType());

            b = 20;
            Console.WriteLine("Type of b - " + b.GetType());
            bits = (Bits)b;
            Console.WriteLine("Type of bits - " + bits.GetType());
        }
    }
}