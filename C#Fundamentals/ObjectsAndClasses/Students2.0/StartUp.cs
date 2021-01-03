using System;
using System.Collections.Generic;

namespace Problem05.Students
{

    class Student
    {
        public string FirstName
        {
            get;
            set;

        }
        public string LastName
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public string Hometown
        {
            get;
            set;

        }
    }

    class Students
    {
        static void Main(string[] args)
        {
            string input;

            List<Student> students = new List<Student>();


            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputInfo = input.Split(" ");




                string firstName = inputInfo[0];

                string lastName = inputInfo[1];

                int age = int.Parse(inputInfo[2]);

                string hometown = inputInfo[3];

                if(IsStudentExist(students, firstName, lastName))
                {
                    Student student = GetStudent(students, firstName, lastName);

                    student.FirstName = firstName;

                    student.LastName = lastName;

                    student.Age = age;

                    student.Hometown = hometown;

                }
                else
                {

                    Student student = new Student();



                    student.FirstName = firstName;

                    student.LastName = lastName;

                    student.Age = age;

                    student.Hometown = hometown;




                    students.Add(student);
                }



            }

            string town = Console.ReadLine();

            students = students
                .FindAll(x => x.Hometown == town);

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }


        }

        public static bool IsStudentExist(List<Student> students, string firstName, string lastName)
        {
            foreach(Student student in students)
            {
                if(student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;

                }

            }

            return false;
        } 

        public static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach(Student student in students)
            {

                if(student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }

                
            }
            return existingStudent;
        }
    }
}
