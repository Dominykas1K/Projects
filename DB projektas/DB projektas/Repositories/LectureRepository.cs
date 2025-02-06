using DB_projektas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DB_projektas.Repositories
{
    public class LectureRepository
    {
        private readonly AppDbContext _context;
        public LectureRepository(AppDbContext context)
        {
            _context = context;
        }
        public void DisplayLectures()
        {
            Console.Clear();
            Console.WriteLine("Iveskite departamento pavadinima");

            string departmentName = ImputHandler.FormatedInput();

            var department = _context.Departments.Include(d => d.Lectures).FirstOrDefault(d => d.Name == departmentName);

            if (department == null)
            {
                Console.WriteLine("Departamentas nerastas");
                return;
            }

            Console.WriteLine($"Departamento \"{department.Name}\"  paskaitos:");
            if(!department.Lectures.Any())
            {
                Console.WriteLine("Paskaitu departamente nera");
            }
            else
            {
                foreach (var lecture in department.Lectures)
                {
                    Console.WriteLine($"{lecture.Title}");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void DeleteAllData()
        {
            Console.Clear();
            _context.Students.RemoveRange(_context.Students);
            _context.Lectures.RemoveRange(_context.Lectures);
            _context.Departments.RemoveRange(_context.Departments);

            _context.SaveChanges();
            Console.WriteLine("Irasai istrinti");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
