using System;
using System.Diagnostics;

namespace part1_6
{
	class Program
	{
		// 1_6
		// Вычислить сумму ряда с заданной точностью и определить, на каком шаге начинает достигаться эта точность.
		// arctg(x) = ...
		// Седлов Лев 11-707

		static double SummaArctg(double x, double eps, out int iterations, out double time)
		{
			double sum = x;
			double item = x;
			int k = 0;
			var sw = new Stopwatch();
			sw.Start();
			while (Math.Abs(item) > eps)
			{
				item *= -1 * (x * x) / (2 * k + 3);
				sum += item;
				k++;
			}
			sw.Stop();
			iterations = k;
			time = sw.Elapsed.TotalMilliseconds;
			return sum;
		}
		static void Main()
		{
			double x = double.Parse(Console.ReadLine());
			double eps = 0.000000001;
			double result = SummaArctg(x, eps, out int iterations, out double time);
			Console.WriteLine($"Результат вычислений: \t{result}. \nТабличное значение: \t{Math.Atan(x)}. \nЗаданная точность достигнута на {iterations} шаге. \nВычисление заняло {time} миллисекунд.");
		}
	}
}
