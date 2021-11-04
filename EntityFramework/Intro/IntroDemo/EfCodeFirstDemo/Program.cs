using EfCodeFirstDemo.Models;
using System;

namespace EfCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SliDoDbContext();
            db.Database.EnsureCreated();
        }
    }
}
