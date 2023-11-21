using ConsoleApp02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Woman : Person, IBabySitter
    {
        protected override string HelloPhrase => "Ура, я - женщинана!!!";
        public Woman(string name) : base(name)
        {
        }
        public Woman(string name, DateTime Birthday) : base(name, Birthday)
        {
        }

        public bool HasMakeup { get; private set; } = false;
        public void PutMakeup()
        {
            Console.WriteLine("Наносит макияж");
            this.HasMakeup = true;
        }
        public void RemoveMakeup()
        {
            Console.WriteLine("Удаляет макияж");
            this.HasMakeup = true;
        }

        public override void SayHello()
        {
            Console.WriteLine("Ура, я - женщина!!!");
        }

        protected override void TakeCareImplementation()
        {
            Console.WriteLine("Кормит ужином, а потом укладывает спать.");
        }

        void IBabySitter.TakeCare()
        {
            if (this.Children != null)
                Console.WriteLine("Сидит с детьми, пока родители на работе.");
        }

        
    }
}
