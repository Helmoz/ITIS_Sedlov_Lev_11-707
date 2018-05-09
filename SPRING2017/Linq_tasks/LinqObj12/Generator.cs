using System;
using System.Collections.Generic;
using System.IO;

namespace LinqObj12
{
    public class FitnesClient
    {
        public int Code { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Duration { get; set; }

        public FitnesClient(string source)
        {
            var tmp = source.Split(' ');
            var array = Array.ConvertAll(tmp, input => Convert.ToInt32(input));
            Code = array[0];
            Year = array[1];
            Month = array[2];
            Duration = array[3];
        }

        public override string ToString()
        {
            return $"{Code}\t{Year}\t{Month}\t{Duration}";
        }
    }

    public class Generator
    {
        public static int[] Years { get; }

        public static int[] Codes { get; }

        public static int[] Months { get; }

        static Generator()
        {
            Years = new int[20];
            for (int i = 0, year = 1998; i < Years.Length; i++, year++)
            {
                Years[i] = year;
            }

            Codes = new int[100];
            for (int i = 0, code = 1; i < Codes.Length; i++, code++)
            {
                Codes[i] = code;
            }

            Months = new int[12];
            for (int i = 0; i < Months.Length; i++)
            {
                Months[i] = i + 1;
            }
        }

        public static void Generate(int size)
        {
            var random = new Random();
            var directory = @"D:\ITIS\Sedlov_Lev_11-707\SPRING2017\Linq_tasks\Data";

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqObj12.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    sw.WriteLine($"{Codes[random.Next(0, Codes.Length)]} {Years[random.Next(0, Years.Length)]} {Months[random.Next(0, Months.Length)]} {random.Next(1, 24)}");
                }
            }
        }

        public static List<FitnesClient> GetCLients(int size)
        {
            Generate(size);
            var directory = @"D:\ITIS\Sedlov_Lev_11-707\SPRING2017\Linq_tasks\Data";

            var list = new List<string>();
            var clients = new List<FitnesClient>();
            using (StreamReader sr = new StreamReader($"{directory}\\LinqObj12.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var client in list)
            {
                clients.Add(new FitnesClient(client));
            }

            return clients;
        }
    }
}
