using System;
using System.Linq;

namespace LinqObj23
{
    class Program
    {
        static void Main()
        {
            var enrollees = Generator.GetEnrollees(10);

            foreach (var enrollee in enrollees)
            {
                Console.WriteLine($"{enrollee}");
            }
            Console.WriteLine();
            
            var answer = enrollees.GroupBy(enrollee => new { enrollee.Year, enrollee.School}, (key, ammount) => new
            {
                Key = key,
                Ammount = ammount.Count()
            })
            .OrderByDescending(item => item.Key.Year)
            .ThenBy(item => item.Key.School);


            foreach (var item in answer)
            {
                Console.WriteLine($"Year: {item.Key.Year} School: {item.Key.School}\tAmmount: {item.Ammount}");
            }
            Console.WriteLine();
        }
    }
}
