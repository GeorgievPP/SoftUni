using EntityRelationsDemo.Models;
using System;

namespace EntityRelationsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var department = new Department { Name = "HR"};

            for (int i = 0; i < 10; i++)
            {
                db.Employees.Add(new Employee
                {
                    FirsName = "Niki_" + i,
                    LastName = "Kostov",
                    StartWorkDate = new DateTime(2010 + i, 1, 1),
                    Salary = 100 + i,
                    Department = department
                });
            }
            db.SaveChanges();
        }
    }
}
