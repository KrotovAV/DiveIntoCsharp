using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public sealed class Man : Person
    {
        protected override string HelloPhrase => "Привет, я -мужик!!!";
        public Man(string name) : base(name)
        {
        }
        public Man(string name, DateTime Birthday) :base (name, Birthday)
        { 
        }

        public bool HasBeard { get; private set; } = true;
        public void Shave()
        {
            Console.WriteLine("Бреется");
            this.HasBeard = false;
        }
        public override void SayHello()
        {
            Console.WriteLine("Привет, я - мужчина!!!");
        }

        public void SayHelloLikeParent()
        {
            base.SayHello();
        }

        public new void Print()
        {
            Console.WriteLine($"Метод из класса Man! Имя {Name}, ДР: {Birthday}");
        }
        protected override void TakeCareImplementation()
        {
            Console.WriteLine("Проверяет уроки и потом идет с детьми на прогулку.");
        }
    }
}
