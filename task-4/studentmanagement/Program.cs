using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentNamespace
{
    class Student
    {
        public string? Name;
        public char Grade;
        public int Age;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>
            {
                new Student { Name = "Alice", Grade = 'B', Age = 20 },
                new Student { Name = "Bob", Grade = 'C', Age = 22 },
                new Student { Name = "Charlie", Grade = 'A', Age = 21 },
                new Student { Name = "David", Grade = 'D', Age = 23 },
                new Student { Name = "Eve", Grade = 'B', Age = 20 }
            };

            Console.WriteLine("Enter a Threshold Grade:");
            char thresholdGrade = Console.ReadLine()[0];

            Console.WriteLine("Students with grade above " + thresholdGrade + ":");

            var filteredStudents = studentList
                .Where(s => s.Grade > thresholdGrade)
                .OrderBy(s => s.Grade);

            Console.WriteLine("Name\tGrade\tAge");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"{student.Name}\t{student.Grade}\t{student.Age}");
            }
        }
    }
}
