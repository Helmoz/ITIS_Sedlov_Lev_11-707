using System.Collections.Generic;
using System.Text;

namespace PolishNotation
{
    public class PolishNotation
    {
        public string Result { get; set; }

        public PolishNotation(string line)
        {
            Result = Convert(line.Split(' '));
        }

        public string Convert(string[] array)
        {
            var operations = new Stack<char>();

            var stringBuilder = new StringBuilder();

            foreach (var symbol in array)
            {
                switch (symbol)
                {
                    case "(":
                    {
                        operations.Push('(');
                        break;
                    }
                    case ")":
                    {
                        while (operations.Peek() != '(')
                            stringBuilder.Append($"{operations.Pop()} ");
                        operations.Pop();
                        break;
                    }
                    default:
                    {
                        if (double.TryParse(symbol, out double number))
                            stringBuilder.Append($"{number} ");
                        else
                        {
                            if (operations.Count == 0)
                                operations.Push(char.Parse(symbol));
                            else
                                operations.OperationsChage(char.Parse(symbol), stringBuilder);
                        }
                        break;
                    }
                }
            }

            while (operations.Count != 0)
                stringBuilder.Append(operations.Pop());

            return stringBuilder.ToString();
        }

        public override string ToString() => Result;
    }
}
