using System;
using System.Diagnostics;

namespace part4_10
{
	class Program
	{
		// 4_10
		// В решении описать 5 статических методов для вычисления значения интеграла по каждой формуле/схеме
		// cos(sqrt(x))^2
		// Седлов Лев 11-707

		static double Function(double x)
		{
			return Math.Pow(Math.Cos(Math.Sqrt(x)), 2);
		}

		static double IntegrateLRect(double a, double b, int n, out double time)
		{
			var sw = new Stopwatch();

			if (b < a || n <= 0)
				throw new ArgumentException("Invalid arguments");

			double delta = (b - a) / n;
			double sum = 0;

			sw.Start();

			for (int i = 0; i < n; i++)
				sum += Function(a + i * delta);

			sw.Stop();
			time = sw.Elapsed.TotalMilliseconds;

			return delta * sum;
		}
		static double IntegrateRRect(double a, double b, int n, out double time)
		{
			var sw = new Stopwatch();

			if (b < a || n <= 0)
				throw new ArgumentException("Invalid arguments");

			double delta = (b - a) / n;
			double sum = 0;

			sw.Start();

			for (int i = 1; i <= n; i++)
				sum += Function(a + i * delta);

			sw.Stop();
			time = sw.Elapsed.TotalMilliseconds;

			return delta * sum;
		}
		static double IntegrateTrap(double a, double b, int n, out double time)
		{
			var sw = new Stopwatch();

			if (b < a || n <= 0)
				throw new ArgumentException("Invalid arguments");

			double delta = (b - a) / (n);
			double sum = 0;

			double prev = Function(a);
			double cur;

			sw.Start();

			for (int i = 1; i <= n; i++)
			{
				cur = Function(a + i * delta);
				sum += (cur + prev);
				prev = cur;
			}

			sw.Stop();
			time = sw.Elapsed.TotalMilliseconds;

			return delta * sum / 2;
		}

		static double IntegrateSimp(double a, double b, int n, out double time)
		{
			var sw = new Stopwatch();

			if (b < a || n <= 0 || n % 2 == 1)
				throw new ArgumentException("Invalid arguments");

			sw.Start();

			double delta = (b - a) / n;
			n /= 2;

			double sum1 = 0;
			for (int i = 1; i < n; i++)
			{
				sum1 += Function(a + 2 * i * delta);
			}

			double sum2 = 0;
			for (int i = 1; i <= n; i++)
			{
				sum2 += Function(a + 2 * (i - 1) * delta);
			}

			sw.Stop();
			time = sw.Elapsed.TotalMilliseconds;

			return delta / 3 * ((Function(a) + Function(b) + 2 * sum1 + 4 * sum2));
		}
		static double IntegrateMCarlo(double a, double b, int n, out double time)
		{
			var sw = new Stopwatch();

			if (b < a || n <= 0)
				throw new ArgumentException("Invalid arguments");


			sw.Start();

			double delta = (b - a) / n;
			double sum = 0;
			Random rnd = new Random();

			for (int i = 0; i < n; i++)
				sum += Function(a + rnd.NextDouble() * (b - a));

			sw.Stop();
			time = sw.Elapsed.TotalMilliseconds;

			return sum * delta;
		}

		static void Main()
		{
			double a = 0, b = 4;
			int n = 1000000;
			double time;
			var result = IntegrateLRect(a, b, n, out time);
			Console.WriteLine($"Метод левых прямоугольников: \t{result}\t{time} миллисекунд;");

			result = IntegrateRRect(a, b, n, out time);
			Console.WriteLine($"Метод првых прямоугольников: \t{result}\t{time} миллисекунд;");

			result = IntegrateTrap(a, b, n, out time);
			Console.WriteLine($"Метод трапеций: \t\t{result}\t{time} миллисекунд;");

			result = IntegrateSimp(a, b, n, out time);
			Console.WriteLine($"Метод Симпсона: \t\t{result}\t{time} миллисекунд;");

			result = IntegrateMCarlo(a, b, n, out time);
			Console.WriteLine($"Метод Монте-Карло: \t\t{result}\t{time} миллисекунд;");
		}
	}
}
