using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqObj12
{
    class Program
    {
        static void Main()
        {
            var cLients = Generator.GetCLients(20);

            double p = (double)new Random().Next(11, 51)/100;
            
            var attendance = new Dictionary<int, int>();

            cLients = cLients.OrderBy(client => client.Year).ToList();
            
            foreach (var client in cLients)
            {
                Console.WriteLine($"{client} ");
            }

            Console.WriteLine();
            Console.WriteLine(p);
            Console.WriteLine();
            
            foreach (var year in cLients.GroupBy(client => client.Year))
            {
                double attendancePerYear= 0;

                var ammountMonthPerYear = 0;
                
                foreach (var fitnesClient in year)
                {
                    attendancePerYear += fitnesClient.Duration;
                }
                
                foreach (var month in year.GroupBy(client => client.Month))
                {
                    double attendancePerMonth = 0;

                    foreach (var fitnesClient in month)
                    {
                        attendancePerMonth += fitnesClient.Duration;
                    }

                    if (attendancePerMonth / attendancePerYear > p)
                        ammountMonthPerYear++;
                }

                attendance.Add(year.Key, ammountMonthPerYear);

            }
           
            foreach (var item in attendance.OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key))
            {
                Console.WriteLine($"{item.Value} {item.Key}");
            }


        }
    }
}
