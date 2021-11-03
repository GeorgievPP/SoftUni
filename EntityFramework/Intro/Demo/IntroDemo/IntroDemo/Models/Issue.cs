using System;
using System.Collections.Generic;

#nullable disable

namespace IntroDemo.Models
{
    public partial class Issue
    {
        public Issue()
        {
            Commits = new HashSet<Commit>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string IssueStatus { get; set; }
        public int RepositoryId { get; set; }
        public int AssigneeId { get; set; }

        public virtual User Assignee { get; set; }
        public virtual Repository Repository { get; set; }
        public virtual ICollection<Commit> Commits { get; set; }
    }
}
