using System;
using System.Collections.Generic;

#nullable disable

namespace IntroDemo.Models
{
    public partial class RepositoriesContributor
    {
        public int RepositoryId { get; set; }
        public int ContributorId { get; set; }

        public virtual User Contributor { get; set; }
        public virtual Repository Repository { get; set; }
    }
}
