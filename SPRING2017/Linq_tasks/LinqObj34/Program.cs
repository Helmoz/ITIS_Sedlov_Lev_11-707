using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            double indebtedness = 0;

            var numberOfFebtors = 0;

            foreach (var inhabitant in inhabitants)
            {
                if (inhabitant.Debt > 0)
                {
                    indebtedness += inhabitant.Debt;
                    numberOfFebtors++;
                }
            }
            
            var ans = inhabitants
                .Where(inhab => inhab.Debt <= indebtedness / numberOfFebtors)
                .OrderByDescending(inhab => inhab.Floor)
                .ThenBy(inhab => inhab.Floor);

            foreach (var inhabitant in ans)
            {
                Console.WriteLine($"{inhabitant.Debt}\t\t{inhabitant.Apartment}\t{inhabitant.Floor}\t{inhabitant.Surname}");
            }


        }
    }
}
