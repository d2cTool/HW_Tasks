using System;
using System.Collections.Generic;

namespace CalcApp
{
    public class PolishNotationParser
    {
        private Stack<double> stack;

        public double Parse(string expr)
        {
            stack = new Stack<double>();
            var str = expr.Trim();

            if (string.IsNullOrEmpty(str))
                return 0;

            try
            {
                for (int i = 0; i < str.Length; i += 2)
                {
                    char ch = str[i];
                    if (i < str.Length - 1)
                    {
                        char delCh = str[i + 1];
                        if (delCh != Common.delimeter)
                            throw new ArgumentException("Invalid expression. Pls chech all delimeters.", "expr");
                    }

                    if (Common.IsOperand(ch))
                        stack.Push(Common.GetOperand(ch));

                    if (Common.IsCommand(ch))
                    {
                        double y = stack.Pop();
                        double x = stack.Pop();
                        stack.Push(Common.GetCommand(ch)(x, y));
                    }
                }

                double res = stack.Pop();

                if (stack.Count > 0)
                    throw new ArgumentException("Invalid expression.", "expr");

                return res;
            }
            catch(Exception)
            {
                Console.WriteLine($"Invalid expression: {str}");
                return 0;
            }
           
        }
    }
}
