using System;

namespace part1_5
{
	class Program
	{
		// 1_5
		// По двум координатам шахматной доски (каждая координата на отдельной строке)
		// определить, находятся эти координаты на одной диагонали (вывести SAME) 
		// или на соседних диагоналях (вывести NEIGHBOUR).
		// Седлов Лев 11-707

		static void Main()
		{
			int x1 = int.Parse(Console.ReadLine());
			int y1 = int.Parse(Console.ReadLine());
			int x2 = int.Parse(Console.ReadLine());
			int y2 = int.Parse(Console.ReadLine());
			Console.WriteLine(Math.Abs(x2 - x1) == Math.Abs(y2 - y1) ? "SAME" : "NEIGHBOUR");
		}
	}
}
