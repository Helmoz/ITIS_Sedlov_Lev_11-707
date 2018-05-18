using System;
using System.Linq;

namespace LinqObj56
{
    class Program
    {
        static void Main()
        {
            var students = Generator.GetStudents(10);


            foreach (var item in students)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var answer = students
                .Where(student => student.Points.Any(point => point > 90))
                .OrderBy(student => student.Surname)
                .ThenBy(student => student.Initials)
                .ThenBy(student => student.School);

            if(answer.Any())
                foreach (var item in answer)
                    Console.WriteLine($"{item.Surname} {item.Initials} {item.School}");
            else
                Console.WriteLine("Требуемые учащиеся не найдены");

            Console.WriteLine();
        }
    }
}
