using System;

namespace detN
{
	public class Program
	{
		public static void Main()
		{
			double[,] m =
			{
				{3, 2, 4, 5 },
				{4, -3, 2, -4 },
				{5, -2, -3, -7 },
				{-3, 4, 2, 9 }
			};

			double det = Calculate(m);
			Console.WriteLine(det);
		}

		public static int Sign(int i, int j)
		{
			if ((i + j) % 2 == 0)
				return 1;
			
			return -1;
		}
		public static double[,] CreateMinor(double[,] m, int i, int j)
		{
			int order = m.GetLength(0);
			double[,] minor = new double[order - 1, order - 1];
			int x = 0, y;
			for (int l = 0; l < order; l++, x++)
			{
				if (l != i)
				{
					y = 0;
					for (int n = 0; n < order; n++)
						if (n != j)
						{
							minor[x, y] = m[l, n];
							y++;
						}
				}
				else
					x--;
			}
			return minor;
		}

		public static double Calculate(double[,] m)
		{
			int order = m.GetLength(0);
			if (order == 2)
			{
				return m[0, 0] * m[1, 1] - m[1, 0] * m[0, 1];
			}
			if (order > 2)
			{
				double result = 0;
				for (int j = 0; j < order; j++)
				{
					double[,] tmp = CreateMinor(m, 0, j);
					result += m[0, j] * (Sign(0, j) * Calculate(tmp));
				}
				return result;
			}
			return m[0, 0];
		}
	}
}