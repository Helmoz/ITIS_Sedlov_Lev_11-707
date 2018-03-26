using System;
using System.IO;

namespace PatienceSort
{
    class Generation
    {
        public static void Generator()
        {
            var random = new Random();
            var directory = Directory.GetCurrentDirectory();
            directory = directory.Substring(0, directory.Length - 9);
            directory += @"Data\";

            for (int i = 10000; i <= 1000000; i += 10000)
            {
                using (StreamWriter sw = new StreamWriter($"{directory}\\{i}.txt"))
                {
                    for (int j = 0; j < i; j++)
                    {
                        sw.WriteLine(random.Next(-i, i));
                    }
                }
            }
        }
    }
}
