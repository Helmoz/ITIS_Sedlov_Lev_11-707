using System;
using System.Collections.Generic;
using System.IO;

namespace LinqObj67
{
    public class Student
    {
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Subject { get; set; }
        public int Grade { get; set; }
        public int Mark { get; set; }
        
        public Student(string source)
        {
            var array = source.Split(' ');
            Grade = int.Parse(array[0]);
            Subject = array[1];
            Surname = array[2];
            Initials = array[3];
            Mark = int.Parse(array[4]);
        }

        public override string ToString()
        {
            return $"{Grade}\t{Subject}\t\t\t{Surname} {Initials}\t{Mark}";
        }
    }

    public class Generator
    {

        public static string[] Surnames { get; }

        public static string[] Initials { get; }

        public static string[] Subjects { get; }


        static Generator()
        {
            Surnames = new[]
            {
                "Attwood", "Becker", "Carter", "Faber", "Haig", "Hodges", "Lewin", "Russel", "Otis"
            };
            Initials = new[]
            {
                "A.A", "A.B", "A.C", "A.D", "F.C"
            };
            Subjects = new[] {"Algebra", "Geometry", "Informatics"};

        }

        public static void Generate(int size)
        {
            var random = new Random();
            var directory = @"D:\ITIS\Sedlov_Lev_11-707\SPRING2017\Linq_tasks\Data";

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqObj67.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    sw.WriteLine($"{random.Next(1,12)} {Subjects[random.Next(0, Subjects.Length)]} {Surnames[random.Next(0, Surnames.Length)]} {Initials[random.Next(0, Initials.Length)]} {random.Next(2, 6)}");
                }
            }
        }

        public static List<Student> GetStudents(int size)
        {
            Generate(size);
            var directory = @"D:\ITIS\Sedlov_Lev_11-707\SPRING2017\Linq_tasks\Data";

            var list = new List<string>();

            var students = new List<Student>();

            using (StreamReader sr = new StreamReader($"{directory}\\LinqObj67.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var student in list)
            {
                students.Add(new Student(student));
            }

            return students;
        }
    }
}
