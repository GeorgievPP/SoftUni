using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Pet pet)
        {
            if(this.data.Count < this.Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.data.Where(n => n.Name == name).FirstOrDefault();
            if(pet != null)
            {
                this.data.Remove(pet);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.data.Where(p => p.Name == name && p.Owner == owner).FirstOrDefault();

            if(pet != null)
            {
                return pet;
            }

            return null;
        }


        public Pet GetOldestPet()
        {
            if (this.data.Any())
            {
                Pet pet = this.data.OrderByDescending(p => p.Age).First();
                return pet;
            }

            return null;
        }

        public string GetStatistics()
        {
            if (this.data.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"The clinic has the following patients:");
                foreach (var pet in data)
                {
                    sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
                }

                return sb.ToString().TrimEnd();
            }

            return null;
        }
    }
}
