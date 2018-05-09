using System;
using System.Collections.Generic;
using System.IO;

namespace LinqObj23
{
    public class Enrollee
    {
        public string Surname { get; set; }
        public int Year { get; set; }
        public int School { get; set; }

        public Enrollee(string source)
        {
            var array = source.Split(' ');
            Surname = array[0];
            Year = int.Parse(array[1]);
            School = int.Parse(array[2]);
        }

        public override string ToString()
        {
            return $"{Year}\t{School}\t{Surname}";
        }
    }

    public class Generator
    {
        public static int[] Years { get; }

        public static int[] Schools { get; }

        public static string[] Surnames { get; }
        
        static Generator()
        {
            Years = new int[10];
            for (int i = 0, year = 2008; i < Years.Length; i++, year++)
            {
                Years[i] = year;
            }

            Schools = new int[50];
            for (int i = 0, school = 1; i < Schools.Length; i++, school++)
            {
                Schools[i] = school;
            }

            Surnames = new[]
            {
                "Abramson", "Attwood", "Becker", "Carter", "Erickson", "Faber", "Haig", "Hodges", "Lewin", "Mackenzie",
                "Oliver", "Ramacey", "Turner", "Wayne", "Harrison", "Youmans", "Russel", "Otis"
            };
        }

        public static void Generate(int size)
        {
            var random = new Random();
            var directory = @"C:\Users\petru\Desktop\Data";

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqObj23.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    sw.WriteLine($"{Surnames[random.Next(0, Surnames.Length)]} {Years[random.Next(0, Years.Length)]} {Schools[random.Next(0, Schools.Length)]}");
                }
            }
        }

        public static List<Enrollee> GetEnrollees(int size)
        {
            Generate(size);
            var directory = @"C:\Users\petru\Desktop\Data";

            var list = new List<string>();
            var enrollees = new List<Enrollee>();
            using (StreamReader sr = new StreamReader($"{directory}\\LinqObj23.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var client in list)
            {
                enrollees.Add(new Enrollee(client));
            }

            return enrollees;
        }
    }
}
