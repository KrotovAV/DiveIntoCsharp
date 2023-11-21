using System.ComponentModel.DataAnnotations;

namespace ConsoleApp052
{
    public class MyEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
    public delegate void MyEventHandler(object sender, MyEventArgs args);

    public class ClassWithEvents
    {
        public event MyEventHandler SomeEvent;
        protected void OnSomeEvent(MyEventArgs args)
        {
            SomeEvent?.Invoke(this, args);
        }
        public void DoSomeWork()
        {
            new Thread(()=>
            {
                Thread.Sleep(5000);
                OnSomeEvent(new MyEventArgs { Message = " всё!" });
            }).Start();
        }
    }

    internal class Program
    {
        private static void ClassWithEvents_SomeEventHandler(object sender, MyEventArgs args)
        {
            Console.WriteLine($"Получено сообщение от класса  {sender}! С  сообщением: {args.Message}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var classWithEvents = new ClassWithEvents();
            classWithEvents.SomeEvent += ClassWithEvents_SomeEventHandler; // подписались на события

            Console.WriteLine("Запущено на выполнение ");

            classWithEvents.DoSomeWork();

            classWithEvents.SomeEvent -= ClassWithEvents_SomeEventHandler; //// отписались на события
        }

        
    }
}