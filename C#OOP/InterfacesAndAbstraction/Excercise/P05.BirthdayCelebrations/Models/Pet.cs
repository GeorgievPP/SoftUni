using P04.BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.BorderControl.Models
{
    public class Pet : IBirthable, IName
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthdate = DateTime.ParseExact(birthday, "dd/mm/yyyy", null);
        }
        public DateTime Birthdate { get; private set; }

        public string Name { get; }
    }
}
