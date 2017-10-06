using System;
using System.Diagnostics;

namespace part1_17
{
	class Program
	{
		// 1_17
		// Константа Каталана
		// Седлов Лев 11-707

		static double CatalansConstant(double eps, out int iterations, out double time)
		{
			double sum = 1;
			double item = 1;
			int n = 1;
			var sw = new Stopwatch();
			sw.Start();
			while (Math.Abs(item) > eps)
			{
				item *= n * (2.0 * n - 1) / (2 * (2 * n + 1) * (2 * n + 1));
				sum += item;
				n++;
			}
			sw.Stop();
			iterations = n;
			time = sw.Elapsed.TotalMilliseconds;
			return sum * 3 / 8 + Math.PI / 8 * Math.Log(Math.Sqrt(3) + 2);
		}

		static void Main()
		{
			double eps = 0.000000000000001;
			double result = CatalansConstant(eps, out int iterations, out double time);

			Console.WriteLine($"Результат вычислений: {result}. \nЗаданная точность достигнута на {iterations} шаге. \nВычисление заняло {time} миллисекунд.");
		}
	}
}
