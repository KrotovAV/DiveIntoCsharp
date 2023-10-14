namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
                        
            Human Peter = new Human("Peter", "Nana", "men", new DateTime(2000, 10, 01));
            Peter.Print();

            Human Nasta = new Human("Nasta", "Nana", "momen", new DateTime(1975, 10, 01));
            Nasta.Print();

            Human Niko = new Human("Niko", "Nana", "men", new DateTime(1975, 08, 02));
            Nasta.Print();

            Peter.mather = Nasta;
            Peter.father = Niko;

            Peter.Print();
        }
    }
}