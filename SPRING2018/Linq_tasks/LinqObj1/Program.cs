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
            Console.WriteLine();

            var minimal = source.Last(client => client.Duration == source.Min(clien => clien.Duration));

            Console.WriteLine($"Duration: {minimal.Duration} Year: {minimal.Year} Month: {minimal.Month}");
        }
    }
}
