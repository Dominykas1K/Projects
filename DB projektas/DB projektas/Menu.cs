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
            DepartmentRepository departmentRepository = new DepartmentRepository();
            while (true)
            {
                Console.WriteLine("Studentu informacine sistema");
                Console.WriteLine("1. Sukurti Departamenta");
                Console.WriteLine("2. Prideti Studentus/Paskaitas i Departamenta");
                Console.WriteLine("3. Sukurti Paskaita ir Priskirti i Departamenta");
                Console.WriteLine("4. Sukurti studenta, ji prideti prie egzistuojancio departamento ir priskirti jam egzistuojančias paskaitas.");
                Console.WriteLine("5. Perkelti Studenta i kita Departamenta");
                Console.WriteLine("6. Atvaizduoti visus Departamento studentus");
                Console.WriteLine("7. Atvaizduoti visas Departamento paskaitas");
                Console.WriteLine("8. Atvaizduoti visas Paskaitas pagal studenta");

                var input = Console.ReadLine();

                using var context = new AppDbContext();

                switch (input)
                {
                    case "1":
                        departmentRepository.CreateDepartment(context);
                        break;
                    case "2":
                        departmentRepository.AddToDepartment(context);
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas");
                        break;

                }
            }
        }
    }
}
