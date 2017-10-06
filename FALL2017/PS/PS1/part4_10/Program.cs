using System;

namespace part4_10
{
	class Program
	{
		// 4_10
		// Найти длину и значение суммы элементов последовательности простых чисел,
		// в сумме дающих простое число, меньшее 1000.
		// Седлов Лев 11-707

		static bool IsPrime(int number)
		{
			//чтоб убедится простое число или нет достаточно проверить не делитьcя ли число на числа до его половины
			for (int i = 2; i <= number / 2; i++)
			{
				if (number % i == 0)
					return false;
			}
			return true;
		}
		static void Main()
		{
			int length = 0;
			int sum = 0;
			for (int i = 2; sum + i < 1000; i++)
			{
				if (IsPrime(i))
				{
					length++;
					if (IsPrime(sum += i))
					{
						Console.WriteLine($"Длина последовательности: {length}, сумма ее элементов: {sum}");
					}
				}
			}
		}
	}
}
