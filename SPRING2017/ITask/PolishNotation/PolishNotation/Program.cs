using System;

namespace PolishNotation
{
    class Program
    {
        static void Main()
        {
            var input = "( 3 * 2 - 5 + 2 / 7 ) * 10";

            var polish = new PolishNotation(input);

            Console.WriteLine(polish);

            var result = new Calculator(polish.ToString());

            Console.WriteLine(result);

        }
    }
}

