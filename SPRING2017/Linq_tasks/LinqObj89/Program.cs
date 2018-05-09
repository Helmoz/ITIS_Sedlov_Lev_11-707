using System;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

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
                Console.WriteLine(item);
            Console.WriteLine();

            foreach (var item in purchases)
                Console.WriteLine(item);
            Console.WriteLine();

            foreach (var item in customers)
                Console.WriteLine(item);
            Console.WriteLine();


            var answer = purchases
                .Join(customers, x => x.Code, x => x.Code, (x, y) => new
                {
                    x.Code,
                    x.VendorCode,
                    x.Name,
                    y.Year
                })
                .Join(products, x => new {x.VendorCode, x.Name}, x => new {x.VendorCode, x.Name}, (x, y) => new
                {
                    x.Code,
                    x.VendorCode,
                    x.Name,
                    x.Year,
                    y.Price
                })
                .GroupBy(x => x.Name, (Name, purchs) => new
                {
                    Name,
                    MinYear = purchs.Where(x => x.Year == purchs.Min(y => y.Year))
                })
                .Select(x => new
                {
                    x.Name,
                    x.MinYear.First().Code,
                    x.MinYear.First().Year,
                    Total = x.MinYear.Sum(y => y.Price)
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Code);
                

            foreach (var item in answer)
                Console.WriteLine($"{item.Name} {item.Code} {item.Year} {item.Total}");
            Console.WriteLine();
        }
    }
}
