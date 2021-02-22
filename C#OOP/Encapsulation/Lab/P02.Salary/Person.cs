namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;


        public Person (string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                this.lastName = value;
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
                this.age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            private set
            {
                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal parcentage)
        {
            if(this.Age > 30)
            {
                this.Salary += (this.Salary * 0.2m);
            }
            else
            {
                this.Salary += (this.Salary * 0.1m);
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
