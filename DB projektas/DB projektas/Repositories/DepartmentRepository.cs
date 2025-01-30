using DB_projektas.Entities;
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
            string input = Console.ReadLine();
            var department = new Department { Name = input };
            context.Departments.Add(department);
            context.SaveChanges();

            Console.WriteLine("Departamentas pridetas");
            Console.ReadKey();
        }

        public void AddToDepartment(AppDbContext context)
        {
            Console.WriteLine("Iveskite departamento pavadinima");
            string input = Console.ReadLine();

            var department = context.Departments.FirstOrDefault(d => d.Name == input);

            if (department == null)
            {
                Console.WriteLine("Departamentas nerastas");
                return;
            }

            Console.WriteLine("1. Prideti studenta");
            Console.WriteLine("2. Prideti paskaita");
            Console.WriteLine("Iveskite pasirinkima");
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Ivesktie studento varda");
                string studentName = Console.ReadLine();

                var student = new Student { Name = studentName, DepartmentID = department.Id};
                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("Studentas pridetas");
            }

            if (choice == "2")
            {
                Console.WriteLine("Iveskite Paskaitos Pavadinima");
                string lectureName = Console.ReadLine();

                var lecture = new Lecture { Title = lectureName };
                department.Lectures.Add(lecture);
                context.SaveChanges();

                Console.WriteLine("Paskaita prideta");
            }
            else 
            {
                Console.WriteLine("Neteisingas pasirinkimas");
            }



        }

        
        

    }
}

