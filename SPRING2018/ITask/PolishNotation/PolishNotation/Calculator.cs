using System;
using System.Collections.Generic;

namespace PolishNotation
{
    class Calculator
    {
        public double Result { get; set; }
        public Calculator(string line)
        {
            Result = Calculate(line.Split(' '));
        }

        public double Calculate(string[] array)
        {
            var calculator = new Stack<double>();
            foreach (var element in array)
            {
                if (double.TryParse(element, out var number))
                    calculator.Push(number);
                else
                {
                    double temp;
                    switch (element)
                    {
                        case "+":
                            calculator.Push(calculator.Pop() + calculator.Pop());
                            break;
                        case "*":
                            calculator.Push(calculator.Pop() * calculator.Pop());
                            break;
                        case "-":
                            temp = calculator.Pop();
                            calculator.Push(calculator.Pop() - temp);
                            break;
                        case "/":
                            temp = calculator.Pop();
                            if (Math.Abs(temp) > 0)
                                calculator.Push(calculator.Pop() / temp);
                            else
                                throw new DivideByZeroException();
                            break;
                    }
                }
            }
            return calculator.Pop();
        }

        public override string ToString() => Result.ToString();
    }
}
