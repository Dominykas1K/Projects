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
        public void DisplayLectures(AppDbContext context)
        {
            Console.Clear();
            Console.WriteLine("Iveskite departamento pavadinima");

            string departmentName = Console.ReadLine();

            var department = context.Departments.Include(d => d.Lectures).FirstOrDefault(d => d.Name == departmentName);

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
    }
}
