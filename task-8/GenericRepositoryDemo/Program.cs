using System;
using System.Threading.Tasks;
using GenericRepositoryDemo.Models;
using GenericRepositoryDemo.Repositories;

namespace GenericRepositoryDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IRepository<Student> studentRepository = new Repository<Student>();
            await studentRepository.AddAsync(new Student { RollNo = "CS239", Name = "Poovarasan", Year = "IV Year", Major = "CSE" });
            await studentRepository.AddAsync(new Student { RollNo = "CS240", Name = "Srinivasan", Year = "IV Year", Major = "CSE" });
            await studentRepository.AddAsync(new Student { RollNo = "EC241", Name = "Suresh", Year = "IV Year", Major = "ECE" });
            await studentRepository.AddAsync(new Student { RollNo = "IS242", Name = "Kumar", Year = "IV Year", Major = "ISE" });
            await studentRepository.AddAsync(new Student { RollNo = "CS243", Name = "Ravi", Year = "IV Year", Major = "CSE" });
            Console.WriteLine("Entity added successfully.");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine("Choose the below options:");
            Console.WriteLine("1. Get all students");
            Console.WriteLine("2. Get student by Rollno");
            Console.WriteLine("3. Update student by Rollno");
            Console.WriteLine("4. Delete student by Rollno");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var students = await studentRepository.GetAllAsync();
                    foreach (var student in students)
                    {
                        Console.WriteLine($"Rollno: {student.RollNo}, Name: {student.Name}, Year: {student.Year}, Major: {student.Major}");
                    }
                    break;

                case 2:
                    Console.WriteLine("Enter Rollno:");
                    string rollno = Console.ReadLine();
                    var studentByRollno = await studentRepository.GetByRollnoAsync(rollno);
                    if (studentByRollno != null)
                    {
                        Console.WriteLine($"Rollno: {studentByRollno.RollNo}, Name: {studentByRollno.Name}, Year: {studentByRollno.Year}, Major: {studentByRollno.Major}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 3:
                    Console.WriteLine("Enter Rollno to update:");
                    rollno = Console.ReadLine();
                    var studentToUpdate = await studentRepository.GetByRollnoAsync(rollno);
                    if (studentToUpdate != null)
                    {
                        Console.WriteLine("Enter new Name:");
                        studentToUpdate.Name = Console.ReadLine();
                        Console.WriteLine("Enter new Year:");
                        studentToUpdate.Year = Console.ReadLine();
                        Console.WriteLine("Enter new Major:");
                        studentToUpdate.Major = Console.ReadLine();
                        await studentRepository.UpdateAsync(studentToUpdate);
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Enter Rollno to delete:");
                    rollno = Console.ReadLine();
                    bool isDeleted = await studentRepository.DeleteAsync(rollno);
                    Console.WriteLine(isDeleted ? "Student deleted successfully." : "Student not found.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
