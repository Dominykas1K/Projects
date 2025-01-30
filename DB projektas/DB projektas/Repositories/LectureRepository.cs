using DB_projektas.Entities;
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
        public void CreateLecture(AppDbContext context)
        {
            Console.WriteLine("Ivesktie paskaitos pavadinima");
            string lectureName = Console.ReadLine();

            Console.WriteLine("Iveskite departamento pavadinima");
            string deparmentName = Console.ReadLine();

            var department = context.Departments.FirstOrDefault(d =>  d.Name == deparmentName);
            if (department == null)
            {
                Console.WriteLine("departamentas nerastas");
            }

            var lecture = new Lecture { Title = lectureName };
            context.Lectures.Add(lecture);
            context.SaveChanges();

            Console.WriteLine("Paskaita prideta");


        }
    }
}
