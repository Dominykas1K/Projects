using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_projektas.Repositories
{
    public class StudentRepository
    {
        public void AddStudentToLecture(AppDbContext context)
        {
            Console.Clear();
            Console.WriteLine("Iveskite studento varda ir pavarde");
            string studentName = Console.ReadLine();
        
            Console.WriteLine("Iveskite departamento pavadinima");
            string departmentName = Console.ReadLine();

            var department = context.Departments.Include(d => d.Lectures).FirstOrDefault(d => d.Name == departmentName);

            if(department == null)
            {
                Console.WriteLine("Departamentas nerastas");
                return;
            }

            var student = context.Students.FirstOrDefault(s => s.Name == studentName);
            if (student == null)
            {
                student = new Entities.Student { Name = studentName, Department = department };
                context.Students.Add(student);
            }
            else
            {
                student.Department = department;
            }

            student.Lectures = department.Lectures.ToList();
            context.SaveChanges();
            Console.WriteLine($"Studentas {student.Name} priskirtas prie \"{department.Name}\" departamento ir jam priskirtos jo paskaitos");

            Console.ReadKey();
            Console.Clear();
        }



        public void DisplayLecturesByStudents(AppDbContext context)
        {
            Console.Clear();
            Console.WriteLine("Iveskite Studento varda ir pavarde");
            string studentName = Console.ReadLine();

            var student = context.Students.Include(s => s.Lectures).FirstOrDefault(s => s.Name == studentName);

            if (student == null)
            {
                Console.WriteLine("Tokio studento nera");
            }

            Console.WriteLine($"Studento {student.Name} paskaitos:");
            if (!student.Lectures.Any())
            {
                Console.WriteLine("Studentas neturi paskaitu");
            }
            else
            {
                foreach (var lecture in student.Lectures)
                {
                    Console.WriteLine($"{lecture.Title}");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
