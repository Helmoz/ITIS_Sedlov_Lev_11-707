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

            for (int i = 10000; i <= 1000000; i += 10000)
            {
                var list = new List<int>();
                using (StreamReader sr = new StreamReader($"{directory}\\{i}.txt")) //string path - путь к файлу
                    while (!sr.EndOfStream)
                        list.Add(int.Parse(sr.ReadLine()));
                var sw = new Stopwatch();
                sw.Start();
                PatienceSort<int>.Sort(list);
                sw.Stop();
                //Console.WriteLine($"{list.Count} {Check(list)} {PatienceSort<int>.Iterations} {sw.ElapsedMilliseconds}");
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