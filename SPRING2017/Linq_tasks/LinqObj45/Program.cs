using System;
using System.Linq;

namespace LinqObj45
{
    class Program
    {
        static void Main()
        {
            var petrolStations = Generator.GetPetrolStations(10);


            foreach (var item in petrolStations)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var answer = petrolStations
                .GroupBy(petrolStation => petrolStation.Street, (street, count) => new { Street = street, Count = count.Count()})
                .OrderBy(group => group.Street);

            foreach (var item in answer)
            {
                Console.WriteLine($"{item.Street}\t{item.Count}");
            }
            Console.WriteLine();

            
        }
    }
}
