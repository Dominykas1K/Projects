using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_projektas.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new();
        public List<Lecture> Lectures { get; set; } = new();
    }
}
