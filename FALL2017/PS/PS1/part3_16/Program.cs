using System;

namespace part3_16
{
	class Program
	{
		// 3_16
		// Считывая числа пока не встретится 0, для каждого положительного числа (строго >0)
		// записать в выходной поток символ "+" соответствующее число раз и ограничитель ";".
		// Седлов Лев 11-707

		static void Main()
		{
			int number = int.Parse(Console.ReadLine());
			while (number != 0)
			{
				if (number > 0)
				{
					for (int i = 0; i < number; i++)
						Console.Write("+");
					Console.WriteLine(";");
				}
				number = int.Parse(Console.ReadLine());
			}

		}
	}
}
