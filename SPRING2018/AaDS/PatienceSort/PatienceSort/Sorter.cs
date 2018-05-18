using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace PatienceSort
{
    class Sorter
    {
        public static void Sort()
        {
            var directory = Directory.GetCurrentDirectory();
            directory = directory.Substring(0, directory.Length - 9);
            directory += @"Data\";
            var random = new Random();

            for (int i = 10000; i <= 1000000; i += 10000)
            {
                var list = new List<int>();
                using (StreamReader sr = new StreamReader($"{directory}\\{i}.txt"))
                    while (!sr.EndOfStream)
                        list.Add(int.Parse(sr.ReadLine()));
                var start = random.Next(0, list.Count);
                var count = list.Count - start ;
                var sw = new Stopwatch();
                list.Sort(start, count, Comparer<int>.Default);
                sw.Start();
                PatienceSort<int>.Sort(list);
                sw.Stop();
                //Console.WriteLine($"{list.Count} {Check(list)} {PatienceSort<int>.Iterations} {sw.ElapsedMilliseconds}");
                //Console.WriteLine($"{list.Count} {PatienceSort<int>.Iterations} {sw.ElapsedMilliseconds}");
                //Console.WriteLine($"{PatienceSort<int>.Iterations}");
                Console.WriteLine($"{sw.ElapsedMilliseconds}");
            }
        }

        public static bool Check(List<int> list)
        {
            for (int i = 0; i < list.Count-1; i++)
            {
                if (!(list[i] <= list[i + 1]))
                    return false;
            }
            return true;
        }
    }
}