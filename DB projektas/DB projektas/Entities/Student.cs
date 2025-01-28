using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_projektas.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        public List<Lecture> Lectures { get; set; } = new();

    }
}
