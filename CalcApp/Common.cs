using System;
using System.Linq;

namespace CalcApp
{
    public static class Common
    {
        public static readonly Func<double, double, double>[] funcs = { Add, Sub, Mul, Div };
        public static char[] commands = { '+', '-', '*', '/' };
        public static char[] operands = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static readonly char delimeter = ' ';

        public static bool IsOperand(char ch)
        {
            return operands.Contains(ch);
        }

        public static double GetOperand(char ch)
        {
            return Array.IndexOf(operands, ch);
        }

        public static bool IsCommand(char ch)
        {
            return commands.Contains(ch);
        }

        public static Func<double, double, double> GetCommand(char ch)
        {
            return funcs[Array.IndexOf(commands, ch)];
        }


        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static double Sub(double x, double y)
        {
            return x - y;
        }

        public static double Mul(double x, double y)
        {
            return x * y;
        }

        public static double Div(double x, double y)
        {
            return x / y;
        }
    }
}
