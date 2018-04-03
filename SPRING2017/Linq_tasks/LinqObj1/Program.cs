using System;
using System.Linq;

namespace LinqObj1
{
    class Program
    {
        static void Main()
        {
            var source = Generator.GetCLients(10);

            foreach (var client in source)
            {
                Console.WriteLine($"{client} ");
            }

            var sorted = source.OrderBy(client => client.Duration);

            var minimal = sorted
                .TakeWhile(client => client.Duration == sorted.First().Duration)
                .Last();

            Console.WriteLine();
            
            Console.WriteLine($"Duration: {minimal.Duration} Year: {minimal.Year} Month: {minimal.Month}");
        }
    }
}
