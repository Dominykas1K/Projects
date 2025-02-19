﻿using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddStudentToLecture()
        {
            Console.Clear();
            Console.WriteLine("Iveskite studento varda ir pavarde");
            string studentName = ImputHandler.FormatedInput();
        
            Console.WriteLine("Iveskite departamento pavadinima");
            string departmentName = ImputHandler.FormatedInput();

            var department = _context.Departments.Include(d => d.Lectures).FirstOrDefault(d => d.Name == departmentName);

            if(department == null)
            {
                Console.WriteLine("Departamentas nerastas");
                return;
            }

            var student = _context.Students.Include(s => s.Lectures).FirstOrDefault(s => s.Name == studentName);
            if (student == null)
            {
                student = new Entities.Student { Name = studentName, Department = department };
                _context.Students.Add(student);
            }
            else
            {
                student.Department = department;
            }

            var newLectures = department.Lectures.Where(l => !student.Lectures.Any(sl => sl.Title == l.Title)).ToList();
            if (newLectures.Any())
            {
                student.Lectures.AddRange(newLectures);
                _context.SaveChanges();
                Console.WriteLine($"Studentas {student.Name} priskirtas prie \"{department.Name}\" departamento ir jam priskirtos {newLectures.Count} naujos paskaitos");
            }
            else
            {
                Console.WriteLine($"Studentas {student.Name} jau turi visas \"{department.Name}\" departamento paskaitas. Nebuvo pridėta jokiu nauju paskaitu");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void TransferStudent()
        {
            Console.Clear();
            Console.WriteLine("Iveskite studento varda ir pavarde");
            string studentName = ImputHandler.FormatedInput();

            Console.WriteLine("Iveskite naujo departamento pavadinima");
            string newDepartmentName = ImputHandler.FormatedInput();

            var student = _context.Students.Include(s => s.Lectures).FirstOrDefault(s => s.Name == studentName);

            if (student == null)
            {
                Console.WriteLine("Studentas nerastas");
                return;
            }

            var newDepartment = _context.Departments.Include(d=> d.Lectures).FirstOrDefault(d => d.Name == newDepartmentName);
            if (newDepartment == null)
            {
                Console.WriteLine("Departamentas nerastas");
                return;
            }

            student.Department = newDepartment;
            student.Lectures = newDepartment.Lectures.ToList();
            _context.SaveChanges();
            Console.WriteLine($"Studentas {student.Name} perkeltas i \"{newDepartment.Name}\" departamenta ");
            Console.ReadKey();
            Console.Clear();

        }


        public void DisplayLecturesByStudents()
        {
            Console.Clear();
            Console.WriteLine("Iveskite Studento varda ir pavarde");
            string studentName = ImputHandler.FormatedInput();

            var student = _context.Students.Include(s => s.Lectures).FirstOrDefault(s => s.Name == studentName);

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
