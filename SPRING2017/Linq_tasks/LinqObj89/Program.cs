using System;
using System.Linq;

namespace LinqObj89
{
    class Program
    {
        static void Main()
        {
            var products = Generator.GetProducts(10);

            var purchases = Generator.GetPurchases(10);

            var customers = Generator.GetCustomers(10);


            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in purchases)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in customers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            var answer = purchases
                .Join(customers, p => p.Code, c => c.Code, (p, c) => new { p, c.Year })
                .Join(products, i=> new {i.p.VendorCode, i.p.Name}, p => new { p.VendorCode, p.Name}, (ps, pr) => new { ps, pr.Price })
                .GroupBy(arg=>arg.ps.p.Name, (name, year) => new
                    {
                        name,
                        year = year.First(x => x.ps.Year == year.Min(y=>y.ps.Year)),
                        total = year.Sum(x=>x.Price)
                    })
                .OrderBy(i=>i.name)
                .ThenBy(i=>i.year.ps.p.Code);
            


            foreach (var item in answer)
            {
                Console.WriteLine($"{item.name} {item.year.ps.p.Code} {item.year.ps.Year} {item.total}");
            }
            Console.WriteLine();



        }
    }
}
