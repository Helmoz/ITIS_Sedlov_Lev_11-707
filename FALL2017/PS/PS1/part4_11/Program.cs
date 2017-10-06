using System;

namespace part4_11
{
	class Program
	{
		// 4_11
		// Найти количество таких чисел n (1<n<10^5), у которых число делителей равно числу делителей числа n+1.
		// Седлов Лев 11-707

		static int NumberOfDividers(int number)
		{
			int counter = 0;
			for (int i = 1; i * i <= number; i++)
				if (number % i == 0)
					counter += 2 - (i * i == number ? 1 : 0);
			return counter;
		}
		static void Main()
		{
			int counter = 0;
			for (int i = 1; i < 100000; i++)
			{
				if (NumberOfDividers(i) == NumberOfDividers(i + 1))
					counter++;
			}
			Console.WriteLine(counter);
		}
	}
}
