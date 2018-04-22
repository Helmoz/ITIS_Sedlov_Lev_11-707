using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqObj78
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = Generator.GetProducts(10);

            var purchases = Generator.GetPurchases(10);


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


            var answer = purchases
                .GroupBy(purchase => purchase.VendorCode, (vendorCode, purchaseses) => new
                    {
                        VendorCode = vendorCode,
                        Count = purchaseses.Count(),
                        Price =  products.Where(x=>x.VendorCode == vendorCode).Max(x=>x.Price)
                    })
                .OrderBy(product=>product.Count)
                .ThenBy(product => product.VendorCode);



            foreach (var item in answer)
            {
                Console.WriteLine($"{item.Count} {item.VendorCode} {item.Price}");
            }
            Console.WriteLine();




        }
    }
}
