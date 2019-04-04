using System;

namespace CalcApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PolishNotationParser.Parse("5 1 2 + 4 * + 3 -"));
            Console.WriteLine(PolishNotationParser.Parse("1 3+"));
        }
    }
}
