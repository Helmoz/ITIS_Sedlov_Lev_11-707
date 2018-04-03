using System;
using System.Collections.Generic;
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

            var listOfEnrollees = new Dictionary<Tuple<int,int>, int>();
            
            foreach (var year in enrollees.GroupBy(item => item.Year))
            {
                foreach (var school in year.GroupBy(item => item.School))
                {
                    listOfEnrollees.Add(Tuple.Create(year.Key, school.Key), school.Count());
                }
            }
            
            foreach (var enrollee in listOfEnrollees.OrderByDescending(pair => pair.Key.Item1).ThenBy(pair => pair.Key.Item2))
            {
                Console.WriteLine(enrollee);
            }
        }
    }
}
