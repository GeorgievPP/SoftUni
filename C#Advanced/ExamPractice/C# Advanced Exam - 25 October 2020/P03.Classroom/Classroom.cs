using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> data;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public string RegisterStudent(Student student)
        {
            if(this.data.Count < this.Capacity)
            {
                this.data.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return $"No seats in the classroom";
        }

        public string DismissStudent(string firsName, string lastName)
        {
            Student student = this.data.Where(s => s.FirstName == firsName && s.LastName == lastName).FirstOrDefault();

            if(student != null)
            {
                this.data.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }

            return $"Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            
            List<Student> list = this.data.Where(s => s.Subject == subject).ToList();
            if(list.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}")
                  .AppendLine($"Students:");
                foreach (var student in list)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }
            string noStudents = "No students enrolled for the subject";

            return noStudents;
        }

        public int GetStudentCount()
        {
            return this.data.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = this.data.Where(s => s.FirstName == firstName && s.LastName == lastName).FirstOrDefault();

            if(student != null)
            {
                return student;
            }

            return null;
        }
    }
}
