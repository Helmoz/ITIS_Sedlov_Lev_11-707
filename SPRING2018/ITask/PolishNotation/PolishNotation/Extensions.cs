using System.Collections.Generic;
using System.Text;

namespace PolishNotation
{
    public static class Extensions
    {
        public static void OperationsChage(this Stack<char> operations, char operation, StringBuilder stringBuilder)
        {
            while (operation.GetPriority() <= operations.Peek().GetPriority())
                stringBuilder.Append($"{operations.Pop()} ");

            operations.Push(operation);
        }

        public static int GetPriority(this char a)
        {
            switch (a)
            {
                case '*':
                case '/':
                    return 3;

                case '+':
                case '-':
                    return 2;

                case '(':
                    return 1;

                default:
                    return 0;
            }
        }
    }
}
