using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firsTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firsTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get
            {
                return this.firsTeam;
            }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get
            {
                return this.reserveTeam;
            }
        }

        public void AddPlayer(Person person)
        {
            if(person.Age < 40)
            {
                this.firsTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }

    }
}
