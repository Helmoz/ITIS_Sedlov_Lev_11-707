using System;
using System.Collections.Generic;
using System.IO;

namespace LinqObj34
{
    public class Inhabitant
    {
        public string Surname { get; set; }
        public double Debt { get; set; }
        public int Apartment { get; set; }
        public int Floor { get; set; }
        
        public Inhabitant(string source)
        {
            var array = source.Split(' ');
            Debt = double.Parse(array[0]);
            Apartment = int.Parse(array[1]);
            Surname = array[2];
            Floor = ((Apartment-1)%36)/4+1;

        }

        public override string ToString()
        {
            return $"{Debt}\t\t{Apartment}\t{Surname}";
        }
    }

    public class Generator
    {

        public static string[] Surnames { get; }

        public static double GetRandomDouble(double min, double max, Random random)
        {
            return Math.Round(random.NextDouble() * (max - min) + min, 2, MidpointRounding.AwayFromZero);
        }

        static Generator()
        {

            Surnames = new[]
            {
                "Abramson", "Attwood", "Becker", "Carter", "Erickson", "Faber", "Haig", "Hodges", "Lewin", "Mackenzie",
                "Oliver", "Ramacey", "Turner", "Wayne", "Harrison", "Youmans", "Russel", "Otis"
            };
        }

        public static void Generate()
        {
            var random = new Random();
            var directory = @"C:\Users\petru\Desktop\Data";

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqObj34.txt"))
            {
                for (int j = 0; j < 144; j++)
                {
                    sw.WriteLine($"{GetRandomDouble(0, 1500, random)} {j+1} {Surnames[random.Next(0, Surnames.Length)]}");
                }
            }
        }

        public static List<Inhabitant> GetInhabitants()
        {
            Generate();
            var directory = @"C:\Users\petru\Desktop\Data";

            var list = new List<string>();

            var inhabitants = new List<Inhabitant>();

            using (StreamReader sr = new StreamReader($"{directory}\\LinqObj34.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var inhabitant in list)
            {
                inhabitants.Add(new Inhabitant(inhabitant));
            }

            return inhabitants;
        }
    }
}
