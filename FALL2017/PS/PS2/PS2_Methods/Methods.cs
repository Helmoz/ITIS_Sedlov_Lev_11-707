using System;

namespace PS2_Methods
{
    public class Methods
    {
		public static double SummaArctg(double x, double eps)
		{
			double sum = x;
			double item = x;
			int k = 1;
			while (Math.Abs(item) > eps)
			{
				item *= -1 * (x * x * (2 * k - 1)) / (2 * k + 1);
				sum += item;
				k++;
			}
			return sum;
		}
		
		public static double CatalansConstant(double eps)
		{
			double sum = 1;
			double item = 1;
			int n = 1;
			while (Math.Abs(item) > eps)
			{
				item *= n * (2.0 * n - 1) / (2 * (2 * n + 1) * (2 * n + 1));
				sum += item;
				n++;
			}
			return sum * 3 / 8 + Math.PI / 8 * Math.Log(Math.Sqrt(3) + 2);
		}
		
		public static double Pi(double eps)
		{
			double sum = 0;
			double item = -6.0;
			int k = 0;
			while (Math.Abs(item) > eps)
			{
				sum += item;
				k++;
				item *= ((50 * k - 6) * k * (2 * k - 1)) / ((50 * k - 56) * 3 * (3 * k - 1) * (3 * k - 2.0));
			}
			return sum;
		}
		
		public static double IntegrateLRect(double a, double b, int n, Func<double, double> function)
		{
			if (b < a || n <= 0)
				throw new ArgumentException("Invalid arguments");

			double delta = (b - a) / n;
			double sum = 0;

			for (int i = 0; i < n; i++)
				sum += function(a + i * delta);

			return delta * sum;
		}
		
		public static double IntegrateRRect(double a, double b, int n, Func<double, double> function)
		{
			if (b < a || n <= 0)
				throw new ArgumentException("Invalid arguments");

			double delta = (b - a) / n;
			double sum = 0;

			for (int i = 1; i <= n; i++)
				sum += function(a + i * delta);

			return delta * sum;
		}
		
		public static double IntegrateTrap(double a, double b, int n, Func<double, double> function)
		{

			if (b < a || n <= 0)
				throw new ArgumentException("Invalid arguments");

			double delta = (b - a) / (n);
			double sum = 0;

			double prev = function(a);
			double cur;


			for (int i = 1; i <= n; i++)
			{
				cur = function(a + i * delta);
				sum += (cur + prev);
				prev = cur;
			}

			return delta * sum / 2;
		}
		
		public static double IntegrateSimp(double a, double b, int n, Func<double, double> function)
		{

			if (b < a || n <= 0 || n % 2 == 1)
				throw new ArgumentException("Invalid arguments");

			double delta = (b - a) / n;
			n /= 2;

			double sum1 = 0;
			for (int i = 1; i < n; i++)
			{
				sum1 += function(a + 2 * i * delta);
			}

			double sum2 = 0;
			for (int i = 1; i <= n; i++)
			{
				sum2 += function(a + 2 * (i - 1) * delta);
			}

			return delta / 3 * ((function(a) + function(b) + 2 * sum1 + 4 * sum2));
		}
		
		public static double IntegrateMCarlo(double a, double b, int n, Func<double, double> function)
		{

			if (b < a || n <= 0)
				throw new ArgumentException("Invalid arguments");


			double delta = (b - a) / n;
			double sum = 0;
			Random rnd = new Random();

			for (int i = 0; i < n; i++)
				sum += function(a + rnd.NextDouble() * (b - a));
			return sum * delta;
		}
	}
}
