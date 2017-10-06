using System;

namespace part1_16
{
	class Program
	{
		// 1_16
		// Проверить, является ли билет «почти счастливым» по московски
		// [следующий или предыдущий к счастливому (abcdef => a+b+c = d+e+f)].
		// Седлов Лев 11-707

		static void Main()
		{
			var ticketNumber = int.Parse(Console.ReadLine());
			int firstSum = 0;
			int secondSum = 0;
			double firstHalfSum = 0;
			double secondHalfSum = 0;
			for (int i = 0; ticketNumber > 0; i++)
			{
				var lastNumber = ticketNumber % 10;
				ticketNumber /= 10;
				if (i < 3)
				{
					secondSum += lastNumber;
					secondHalfSum = secondHalfSum / 10 + lastNumber;
				}
				else
				{
					firstSum += lastNumber;
					firstHalfSum = firstHalfSum / 10 + lastNumber;
				}
			}

			int firstPart = (int)(firstHalfSum * 100);
			int secondPart = (int)(secondHalfSum * 100);

			if (Math.Abs(firstSum - secondSum) == 1 || Math.Abs(firstPart - secondPart) == 1)
				Console.WriteLine("It's almost a lucky ticket");
			else
				Console.WriteLine("No");

		}
	}
}
