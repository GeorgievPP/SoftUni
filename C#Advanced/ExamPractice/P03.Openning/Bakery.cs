using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Employee employee)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = this.data.Where(n => n.Name == name).FirstOrDefault();

            if (employee != null)
            {
                this.data.RemoveAll(n => n.Name == name);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            if (this.data.Any())
            {
                Employee employee = this.data.OrderByDescending(e => e.Age).First();
                return employee;

            }

            return null;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = this.data.Where(n => n.Name == name).FirstOrDefault();
            if(employee != null)
            {
                return employee;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach(var employee in data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
