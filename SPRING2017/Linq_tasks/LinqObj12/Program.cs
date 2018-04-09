using System;
using System.Linq;

namespace LinqObj12
{
    class Program
    {
        static void Main()
        {
            var clients = Generator.GetCLients(20);

            double p = (double)new Random().Next(10, 50)/100;

            clients = clients.OrderBy(client => client.Year).ToList();

            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
            Console.WriteLine();

            Console.WriteLine(p);
            Console.WriteLine();

            var answer = clients
                .GroupBy(client => client.Year,
                (year, fitnesClients) => new
                {
                    Year = year,
                    Count = fitnesClients.Count(client => (double)client.Duration / fitnesClients.Sum(fitnesClient => fitnesClient.Duration) > p)
                })
                .OrderByDescending(client => client.Count)
                .ThenBy(client => client.Year);

            foreach (var item in answer)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
