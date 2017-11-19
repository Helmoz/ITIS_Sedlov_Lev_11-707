using System;
using System.Diagnostics;

class Program
{
	// 3_5
	// Произвести вычисления по рекуррентной схеме
	// Седлов Лев 11-707

	static double GetCos(double eps)
	{
		
		double previousNumber = 5;
		double currentNumber = 0;
		
		while (Math.Abs(currentNumber - previousNumber) >= eps)
		{
			previousNumber = currentNumber;
			currentNumber = Math.Cos(previousNumber);
		}
		return currentNumber;
	}
	static void Main()
	{
		double eps = 0.00000000000001;
		double result = GetCos(eps);

		Console.WriteLine($"Результат вычислений: {result} {Math.Acos(result)}");
	}
}