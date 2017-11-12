using System;

namespace detN
{
	public class Program
	{
		public static void Main()
		{
			double[,] matrix =
			{
				{1, -1, 1, -2 },
				{1, 3, -1, 3},
				{-1, -1, 4, 3},
				{-3, 0, -8, -13},
			};

			double det = Calculate(matrix);
			Console.WriteLine(det);
		}

		public static int Sign(int i, int j)
		{
			if ((i + j) % 2 == 0)
				return 1;
			
			return -1;
		}
		public static double[,] CreateMinor(double[,] matrix, int i, int j)
		{
			int order = matrix.GetLength(0);
			double[,] minor = new double[order - 1, order - 1];
			int x = 0, y;
			for (int k = 0; k < order; k++, x++)
			{
				if (k != i)
				{
					y = 0;
					for (int l = 0; l < order; l++)
						if (l != j)
						{
							minor[x, y] = matrix[k, l];
							y++;
						}
				}
				else
					x--;
			}
			return minor;
		}

		public static double Calculate(double[,] matrix)
		{
			int order = matrix.GetLength(0);
			if (order == 2)
			{
				return matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];
			}
			if (order > 2)
			{
				double result = 0;
				for (int j = 0; j < order; j++)
				{
					double[,] tmp = CreateMinor(matrix, 0, j);
					result += matrix[0, j] * (Sign(0, j) * Calculate(tmp));
				}
				return result;
			}
			return matrix[0, 0];
		}
	}
}