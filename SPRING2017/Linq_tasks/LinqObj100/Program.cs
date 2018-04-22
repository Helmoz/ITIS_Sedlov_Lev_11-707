using System;
using System.Linq;

namespace LinqObj100
{
    class Program
    {
        static void Main()
        {
            var prices = Generator.GetProducts(10);

            var goods = Generator.GetPurchases(10);

            var customers = Generator.GetCustomers(10);

            var orders = Generator.GetProductsFrom(10);

            foreach (var item in prices)
                Console.WriteLine(item);
            Console.WriteLine();

            foreach (var item in goods)
                Console.WriteLine(item);
            Console.WriteLine();

            foreach (var item in customers)
                Console.WriteLine(item);
            Console.WriteLine();
            
            foreach (var item in orders)
                Console.WriteLine(item);
            Console.WriteLine();

            var result = goods
                .Join(orders, o => o.VendorCode, g => g.VendorCode, (o, g) => new {o, g})
                .Join(prices, t => new {t.o.VendorCode, t.o.Name}, p => new {p.VendorCode, p.Name}, (t, p) => new {t, p})
                .Join(customers, t => t.t.o.Code, c => c.Code, (t, c) => new {t.t.o.Name, t.t.g.Country, c.Year, t.p.Price, c.Code})
                .GroupBy(tmp => new {tmp.Name, tmp.Country})
                .Select(grouping => new {grouping, maxby = grouping.Max(x => x.Year)})
                .Select(t => new {t, sum = t.grouping.Sum(x => x.Price)})
                .Select(t => new
                    {
                        Items = t.t.grouping
                            .Where(x => x.Year == t.t.maxby)
                            .Distinct()
                            .Select(x => new {x.Country, x.Name, x.Year, x.Code, Sum = t.sum})
                    })
                .SelectMany(x => x.Items);

            foreach (var item in result)
                Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}
