using System;
using System.Collections.Generic;
using System.Linq;

namespace CalcApp
{
    public static class PolishNotationParser
    {
        static Stack<double> stack = new Stack<double>();
        static readonly Func<double, double, double>[] funcs = { Add, Sub, Mul, Div };

        static char[] commands = { '+', '-', '*', '/' };
        static char[] operands = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static readonly char delimeter = ' ';

        public static double Parse(string expr)
        {
            var str = expr.Trim();

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            for (int i = 0; i < str.Length; i += 2)
            {
                char ch = str[i];

                if (i < str.Length - 1)
                {
                    char delCh = str[i + 1];

                    if (delCh != delimeter)
                        throw new ArgumentException("Invalid expression. Pls chech all delimeters.", "expression");
                }

                if (IsOperand(ch))
                    stack.Push(GetOperand(ch));

                if (IsCommand(ch))
                {
                    double y = stack.Pop();
                    double x = stack.Pop();
                    stack.Push(GetCommand(ch)(x, y));
                }
            }

            double res = stack.Pop();
            return res;
        }

        static bool IsCommand(char ch)
        {
            return commands.Contains(ch);
        }

        static Func<double, double, double> GetCommand(char ch)
        {
            return funcs[Array.IndexOf(commands, ch)];
        }

        static bool IsOperand(char ch)
        {
            return operands.Contains(ch);
        }

        static double GetOperand(char ch)
        {
            return Array.IndexOf(operands, ch);
        }

        static double Add(double x, double y)
        {
            return x + y;
        }

        static double Sub(double x, double y)
        {
            return x - y;
        }

        static double Mul(double x, double y)
        {
            return x * y;
        }

        static double Div(double x, double y)
        {
            return x / y;
        }
    }
}
