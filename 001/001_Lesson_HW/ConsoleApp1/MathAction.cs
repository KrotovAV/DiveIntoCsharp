using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MathAction
    {
        public static List<object> MathExprtAct(List<object> mathExpr, string mathAct)
        {
            while (mathExpr.Contains(mathAct))
            {
                for (int i = 1; i< mathExpr.Count - 1; i += 2)
                {
                    if (mathExpr[i].Equals(mathAct))
                    {
                        if (mathAct.Equals("*")) mathExpr[i - 1] = (double)mathExpr[i - 1] * (double)mathExpr[i + 1];
                        else if (mathAct.Equals("/")) mathExpr[i - 1] = (double)mathExpr[i - 1] / (double)mathExpr[i + 1];
                        else if(mathAct.Equals("-")) mathExpr[i - 1] = (double)mathExpr[i - 1] - (double)mathExpr[i + 1];
                        else if(mathAct.Equals("+")) mathExpr[i - 1] = (double)mathExpr[i - 1] + (double)mathExpr[i + 1];
                        mathExpr.RemoveAt(i);
                        mathExpr.RemoveAt(i);
                    }
                }
                foreach (object element in mathExpr) { Console.Write(element); }
                Console.WriteLine();
            }
        return mathExpr;
        }
    }
}
