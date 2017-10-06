using System;

namespace part3_14
{
	class Program
	{
		// 3_14
		// Считывая числа пока не встретится 0, найти длину самой длинной последовательности чётных чисел.
		// Седлов Лев 11-707

		static void Main()
		{
			int input = int.Parse(Console.ReadLine());
			int tmplength = 0;
			int result = 0;
			while (input != 0)
			{
				if (input % 2 == 0)
					tmplength++;
				else
				{
					if (tmplength > result)
						result = tmplength;
					tmplength = 0;
				}
				input = int.Parse(Console.ReadLine());
			}
			if (tmplength > result)
				result = tmplength;
			Console.WriteLine(result);
		}
	}
}
