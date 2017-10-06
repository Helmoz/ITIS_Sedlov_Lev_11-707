using System;
using System.Diagnostics;

namespace part2_6
{
	class Program
	{
		// 2_6
		// Реализовать статический метод, вычисляющий значение числа Пи с точностью eps.
		// Формула через биномиальные коэффициенты.
		// Седлов Лев 11-707

		static double Pi(double eps, out int iterations, out double time)
		{
			double sum = 0;
			double item = -6.0;
			int k = 0;
			var sw = new Stopwatch();
			sw.Start();
			while (Math.Abs(item) > eps)
			{
				sum += item;
				k++;
				item *= ((50 * k - 6) * k * (2 * k - 1)) / ((50 * k - 56) * 3 * (3 * k - 1) * (3 * k - 2.0));
			}
			sw.Stop();
			iterations = k;
			time = sw.Elapsed.TotalMilliseconds;
			return sum;
		}
		static void Main()
		{
			double eps = 0.0000000000000001;
			double result = Pi(eps, out int iterations, out var time);

			Console.WriteLine($"Результат вычислений: {result}. \nЗаданная точность достигнута на {iterations} шаге. \nВычисление заняло {time} миллисекунд.");
		}
	}
}
