using System;
using System.Collections.Generic;

#nullable disable

namespace IntroDemo.Models
{
    public partial class Commit
    {
        public Commit()
        {
            Files = new HashSet<File>();
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public int? IssueId { get; set; }
        public int RepositoryId { get; set; }
        public int ContributorId { get; set; }

        public virtual User Contributor { get; set; }
        public virtual Issue Issue { get; set; }
        public virtual Repository Repository { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
