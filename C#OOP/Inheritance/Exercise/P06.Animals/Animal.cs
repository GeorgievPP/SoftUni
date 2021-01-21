using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private const string ERROR_MESSEGE = "Invalid input";
        private const int MIN_AGE = 1;
        private string name;
        private int age;
        private string gender;


        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ERROR_MESSEGE);
                }

                this.name = value;
            }

        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if(value < MIN_AGE)
                {
                    throw new ArgumentException(ERROR_MESSEGE);
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                if(value != "Male" && value != "Female")
                {
                    throw new ArgumentException(ERROR_MESSEGE);
                }

                this.gender = value;
            }

        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{this.GetType().Name}")
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .AppendLine($"{this.ProduceSound()}");

            return sb.ToString().TrimEnd();
        }

    }
}
