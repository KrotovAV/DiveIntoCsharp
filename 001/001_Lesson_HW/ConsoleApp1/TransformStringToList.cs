using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TransformStringToList
    {
        public static string ModifyString(string input)
        {
            input = input.Replace(" ", "");
            if (!char.IsDigit(input[0]))
            {
                input = "0" + input;
            }

            if (!char.IsDigit(input[input.Length - 1]))
            {
                input = input.Substring(0, input.Length - 1);
            }

            input = input.Replace("*", " * ");
            input = input.Replace("/", " / ");
            input = input.Replace("+", " + ");
            input = input.Replace("-", " - ");
            //Console.WriteLine(input);

            return input;
        }
        public static List<object> StringToList(string input)
        {
            List<string> inputListString = input.Split(' ').ToList();
            //foreach (object element in inputListString) { Console.Write(element); }
            List<object> mathematicalExpressiont = new List<object>();
            foreach (string element in inputListString)
            {
                if ((element == "*") || (element == "/") || (element == "+") || (element == "-"))
                {
                    mathematicalExpressiont.Add(element);
                }
                else
                {
                    mathematicalExpressiont.Add(double.Parse(element));
                }
            }
            return mathematicalExpressiont;
        }
    }
}
