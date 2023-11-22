using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp06
{
    class MyParse
    {
        public static List<char> operands = new List<char> { '+', '-', '*', '/', '=', '#' };
        internal static bool MyTryParseToDouble(string myString, out double num)
        {
            myString = new string(myString.Where(t => (char.IsDigit(t)) | t.Equals('-')).ToArray());
            num = 0;
            try
            {
                num = Convert.ToDouble(myString);
                return true;
            }
            catch
            {
                throw new MyFormatException("Ошибка формата ввода ");
            }
        }
        internal static char Parser(string read, out double x)
        {
            char retChar;
            x = 0;
            read.Replace(" ", "");

            if (read.Length > 0)
            {
                if (operands.Contains(read[0]))
                {
                    retChar = read[0];
                    read = read.Remove(0, 1);
                }
                else
                {
                    retChar = '\0';
                }
                if (read.Length != 0)
                {
                    try
                    {
                        if (MyParse.MyTryParseToDouble(read, out x));
                    }
                    catch (MyFormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода! Нужно ввести действие и число!");
                retChar = ' ';
            }
            return retChar;
        }
    }
}
