using System;
using System.Linq;

namespace LinqObj45
{
    class Program
    {
        static void Main()
        {
            var petrolStations = Generator.GetPetrolStations(42);

            petrolStations = petrolStations.OrderBy(x => x.Street).ToList();

            foreach (var item in petrolStations)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var answer = petrolStations
                .GroupBy(petrolStation => petrolStation.Street, (street, stations) => new { Street = street, Count = stations.GroupBy(petrolStation=>petrolStation.Company).Count()})
                .OrderBy(group => group.Street);

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.Street} {item.Count}");
            }
            Console.WriteLine();


        }
    }
}
