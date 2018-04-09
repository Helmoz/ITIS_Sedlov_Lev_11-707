using System;
using System.Linq;

namespace LinqObj67
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = Generator.GetStudents(100);

            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var answer = students
                .GroupBy(student => new {student.Mark, student.Grade, student.Surname, student.Initials}, (stud, count) => new{ stud, count=count.Count()})
                .Where(mark => mark.stud.Mark == 2)
                .OrderByDescending(stud => stud.stud.Grade)
                .ThenBy(stud => stud.stud.Surname)
                .ThenBy(stud => stud.stud.Initials);

            
            if (answer.Any())
                foreach (var item in answer)
                    Console.WriteLine($"{item.stud.Grade} {item.stud.Surname} {item.stud.Initials} {item.count}");
            else
                Console.WriteLine("Требуемые учащиеся не найдены");


        }
    }
}
