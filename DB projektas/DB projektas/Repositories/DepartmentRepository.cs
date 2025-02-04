using DB_projektas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DB_projektas.Repositories
{
    public class DepartmentRepository
    {
        public void CreateDepartment(AppDbContext context)
        {
            Console.Clear();
            Console.WriteLine("Iveskite departamento pavadinima");
            string input = ImputHandler.FormatedInput();
            var existingDepartment = context.Departments.FirstOrDefault(d => d.Name == input);
            if (existingDepartment != null)
            {
                Console.WriteLine("Toks departamentas jau egzistuoja");
            }
            else
            {
                var department = new Department { Name = input };
                context.Departments.Add(department);
                context.SaveChanges();

                Console.WriteLine("Departamentas pridetas");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void AddToDepartment(AppDbContext context)
        {
            Console.Clear();
            Console.WriteLine("Iveskite departamento pavadinima");
            string input = ImputHandler.FormatedInput();

            var department = context.Departments.FirstOrDefault(d => d.Name == input);

            if (department == null)
            {
                Console.WriteLine("Departamentas nerastas");
                return;
            }

            Console.WriteLine("Iveskite paskaitos pavadinima");
            string lectureName = ImputHandler.FormatedInput();

            var existingLecture = department.Lectures.FirstOrDefault(l => l.Title == lectureName);
            if (existingLecture != null)
            {
                Console.WriteLine("Tokia paskaita siame departamente jau egzistuoja");
            }
            else
            {
                var lecture = new Lecture { Title = lectureName };
                department.Lectures.Add(lecture);
                context.SaveChanges();
                Console.WriteLine("Paskaita prideta");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplayStudents(AppDbContext context)
        {
            Console.Clear();
            Console.WriteLine("Iveskite departamento pavadinima");
            string departmentName = ImputHandler.FormatedInput(); 

            var department = context.Departments.FirstOrDefault(d => d.Name == departmentName);
            if (department == null)
            {
                Console.WriteLine("Departamentas nerastas");
                return;
            }

            var students = context.Students.Where(s =>s.DepartmentID == department.Id).ToList();

            Console.WriteLine($"Departamento \"{department.Name}\"  studentai:");
            if (students.Count == 0)
            {
                Console.WriteLine("Siame departamente nera studentu");
            }
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student.Name);
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}

