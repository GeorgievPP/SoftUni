using System;
using System.Collections.Generic;

#nullable disable

namespace IntroDemo.Models
{
    public partial class Repository
    {
        public Repository()
        {
            Commits = new HashSet<Commit>();
            Issues = new HashSet<Issue>();
            RepositoriesContributors = new HashSet<RepositoriesContributor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<RepositoriesContributor> RepositoriesContributors { get; set; }
    }
}
