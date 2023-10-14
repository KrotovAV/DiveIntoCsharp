using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Написать программу-калькулятор, вычисляющую выражения вида
            //a + b, a - b, a / b, a * b, введенные из командной строки,
            //и выводящую результат выполнения на экран.

            Console.WriteLine("Введите выражение для вычисления:");

            //string input = Console.ReadLine();

            string input = " - 20+ 2*3 0 + 4 * 5-   4/2+3 +2";
            //Console.WriteLine(input);

            input = TransformStringToList.ModifyString(input);
            List<object> mathematicalExpressiont = TransformStringToList.StringToList(input);
            //foreach (object element in mathematicalExpressiont) { Console.WriteLine(element.GetType()); }

            mathematicalExpressiont = MathAction.MathExprtAct(mathematicalExpressiont, "*");
            mathematicalExpressiont = MathAction.MathExprtAct(mathematicalExpressiont, "/");
            mathematicalExpressiont = MathAction.MathExprtAct(mathematicalExpressiont, "-");
            mathematicalExpressiont = MathAction.MathExprtAct(mathematicalExpressiont, "+");
        }
    }
}