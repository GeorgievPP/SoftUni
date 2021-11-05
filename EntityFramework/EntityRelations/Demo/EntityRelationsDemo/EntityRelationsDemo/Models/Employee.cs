using System;
using System.Collections.Generic;
using System.Text;

namespace EntityRelationsDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Egn { get; set; }

        public string FirsName { get; set; }

        public string LastName { get; set; }

        public DateTime? StartWorkDate { get; set; }

        public decimal? Salary { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
