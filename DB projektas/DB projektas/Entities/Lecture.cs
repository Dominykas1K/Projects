using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_projektas.Entities
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Department> Departments { get; set; } = new();
        public List<Student> Students { get; set; } = new();
    }
}
