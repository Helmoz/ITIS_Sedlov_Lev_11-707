using System;
using System.Collections.Generic;
using System.IO;

namespace LinqObj45
{
    public class PetrolStation
    {
        public string Company { get; set; }
        public int Price { get; set; }
        public int Brand { get; set; }
        public string Street { get; set; }

        public PetrolStation(string source)
        {
            var array = source.Split(' ');
            Company = array[0];
            Price = int.Parse(array[1]);
            Brand = int.Parse(array[2]);
            Street = array[3];

        }

        public override string ToString()
        {
            return $"{Company}\t{Price}\t{Brand}\t{Street}";
        }
    }

    public class Generator
    {

        public static string[] Companies { get; }

        public static int[] Brands { get; }

        public static string[] Streets { get; }

        static Generator()
        {
            Companies = new[]
            {
                "Lukoil", "Rosneft", "Gazprom", "Tatneft", "TNK", "Ucos"
            };

            Streets = new[]
            {
                "Adoratskogo", "Gavrilova", "Dekabristov", "Korolenko", "Yamasheva", "Tolstogo", "Absalyamova"
            };

            Brands = new[] {92, 95, 98};

        }

        public static void Generate(int size)
        {
            var random = new Random();
            var directory = @"C:\Users\petru\Desktop\Data";
            var dict = new List<Tuple<string, string, int>>();

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqObj45.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    var company = Companies[random.Next(0, Companies.Length)];
                    var street = Streets[random.Next(0, Streets.Length)];
                    var brand = Brands[random.Next(0, Brands.Length)];
                    while (true)
                    {
                        if (!dict.Contains(new Tuple<string, string, int>(street, company, brand)))
                        {
                            sw.WriteLine($"{company} {random.Next(380, 450)} {brand} {street}");
                            dict.Add(Tuple.Create(street, company, brand));
                            break;
                        }
                        else
                        {
                            company = Companies[random.Next(0, Companies.Length)];
                            street = Streets[random.Next(0, Streets.Length)];
                            brand = Brands[random.Next(0, Brands.Length)];
                        }
                    }

                }
            }
        }

        public static List<PetrolStation> GetPetrolStations(int size)
        {
            Generate(size);
            var directory = @"C:\Users\petru\Desktop\Data";

            var list = new List<string>();

            var petrolStations = new List<PetrolStation>();

            using (StreamReader sr = new StreamReader($"{directory}\\LinqObj45.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var petrolStation in list)
            {
                petrolStations.Add(new PetrolStation(petrolStation));
            }

            return petrolStations;
        }
    }
}
