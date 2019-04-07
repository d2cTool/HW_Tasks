using System;

namespace CalcApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PolishNotationParser parser = new PolishNotationParser();
            Console.WriteLine(parser.Parse("5 1 2 + 4 * + 3 -"));
            Console.WriteLine(parser.Parse("1 3+"));
        }
    }
}
