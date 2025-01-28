using DB_projektas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_projektas
{
    public class AppDbContext : DbContext
    {
        public DbSet<Entities.Lecture> Lectures { get; set; }
        public DbSet<Entities.Student> Students { get; set; }
        public DbSet<Entities.Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DB_Project;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
