using System;
using System.Linq;

namespace LinqObj34
{
    class Program
    {
        static void Main()
        {
            var inhabitants = Generator.GetInhabitants();

            foreach (var inhabitant in inhabitants)
            {
                Console.WriteLine(inhabitant);
            }
            Console.WriteLine();
            
            var answer = inhabitants
                .Where(inhab => inhab.Debt <= inhabitants.Average(inhabitant => inhabitant.Debt > 0 ? inhabitant.Debt : 0))
                .OrderByDescending(inhabitant => inhabitant.Floor)
                .ThenBy(inhabitant => inhabitant.Floor);

            foreach (var inhabitant in answer)
            {
                Console.WriteLine($"{inhabitant.Debt}\t\t{inhabitant.Apartment}\t{inhabitant.Floor}\t{inhabitant.Surname}");
            }


        }
    }
}
