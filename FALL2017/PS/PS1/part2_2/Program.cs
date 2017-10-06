using System;

namespace part2_2
{
	class Program
	{
		// 2_2 
		// По двум первым членам арифметической прогрессии и числу k вычислить значение k-го члена.
		// Седлов Лев 11-707

		static void Main()
		{
			int num1 = int.Parse(Console.ReadLine());
			int num2 = int.Parse(Console.ReadLine());
			int k = int.Parse(Console.ReadLine());

			Console.WriteLine(num1 + (num2 - num1) * (k - 1));
		}
	}
}
