using DB_projektas.Entities;
using DB_projektas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DB_projektas
{
    public class Menu
    {
        public void Run()
        {
            using var context = new AppDbContext();
            var departmentRepository = new DepartmentRepository(context);
            var lectureRepository = new LectureRepository(context);
            var studentRepository = new StudentRepository(context);
            while (true)
            {
                Console.WriteLine("Studentu informacine sistema");
                Console.WriteLine("1. Sukurti Departamenta");
                Console.WriteLine("2. Prideti Paskaitas i Departamenta");
                Console.WriteLine("3. Sukurti studenta, ji prideti prie egzistuojancio departamento ir priskirti jam egzistuojančias paskaitas");
                Console.WriteLine("4. Perkelti Studenta i kita Departamenta");
                Console.WriteLine("5. Atvaizduoti visus Departamento studentus");
                Console.WriteLine("6. Atvaizduoti visas Departamento paskaitas");
                Console.WriteLine("7. Atvaizduoti visas Paskaitas pagal studenta");
                Console.WriteLine("8. Istrinti visus irasus is duomenu bazes");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        departmentRepository.CreateDepartment();
                        break;
                    case "2":
                        departmentRepository.AddToDepartment();
                        break;                   
                    case "3":
                        studentRepository.AddStudentToLecture();
                        break;
                    case "4":
                        studentRepository.TransferStudent();
                        break;
                    case "5":
                        departmentRepository.DisplayStudents();                      
                        break;
                    case "6":
                        lectureRepository.DisplayLectures();
                        break;
                    case "7":
                        studentRepository.DisplayLecturesByStudents();
                        break;
                    case "8":
                        lectureRepository.DeleteAllData();
                        break;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            }
        }
    }
}
