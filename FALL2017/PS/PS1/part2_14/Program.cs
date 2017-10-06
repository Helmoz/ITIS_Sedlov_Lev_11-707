using System;

namespace part2_14
{
	class Program
	{
		// 2_14
		// Найти произведение цифр в k-ичной системе счисления (k от 2 до 10)
		// десятичного натурального числа n.
		// Седлов Лев 11-707

		static void Main()
		{
			int number = int.Parse(Console.ReadLine());
			int k = int.Parse(Console.ReadLine());
			int result = 1;
			while (number > 0)
			{
				result *= number % k;
				number /= k;
			}
			Console.WriteLine(result);
		}
	}
}
