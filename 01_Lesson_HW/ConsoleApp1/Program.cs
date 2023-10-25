namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human NoMan = new Human(null, null, null, new DateOnly(0001, 01, 01));
            //Human NoMan = new Human("NoNown", "NoNown", "NoNown", new DateOnly(0001, 01, 01));

            Human Peter = new Human("Peter", "Nana", "men", new DateOnly(1980, 10, 01));
            Console.WriteLine(Peter.PrintHuman());

            Human Omely = new Human("Omely", "Nana", "women", new DateOnly(1980, 10, 01));
            Console.WriteLine(Omely.PrintHuman());

            Human Nasta = new Human("Nasta", "Nana", "momen", new DateOnly(1975, 10, 01));
            Console.WriteLine(Nasta.PrintHuman());

            Human Niko = new Human("Niko", "Nana", "men", new DateOnly(1975, 08, 02));
            Console.WriteLine(Nasta.PrintHuman());

            Human Nastsia = new Human("Nastsia", "Kava", "momen", new DateOnly(2002, 10, 01));
            Console.WriteLine(Niko.PrintHuman());

            Human Arch = new Human("Arch", "Nana", "men", new DateOnly(2012, 08, 02));
            Console.WriteLine(Arch.PrintHuman());

            Human Varia = new Human("Varia", "Nana", "momen", new DateOnly(1955, 10, 01));
            Console.WriteLine(Varia.PrintHuman());

            Human Vic = new Human("Vic", "Nana", "men", new DateOnly(1953, 08, 02));
            Console.WriteLine(Vic.PrintHuman());


            Human Gavr = new Human("Gavr", "Kava", "men", new DateOnly(2000, 08, 02));
            Console.WriteLine(Gavr.PrintHuman());


            Family PetersF = new(Peter, Omely, Niko, Nasta, Arch, Nastsia, Vic, Varia);

            Console.WriteLine(PetersF.PrintOwnerFamily());

            Family NastsiasF = new(Nastsia, Gavr, NoMan, NoMan, NoMan, NoMan, NoMan, NoMan);
            Console.WriteLine(NastsiasF.PrintOwnerFamily());
        }
    }
}