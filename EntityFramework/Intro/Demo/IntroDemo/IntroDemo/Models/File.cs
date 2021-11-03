using System;
using System.Collections.Generic;

#nullable disable

namespace IntroDemo.Models
{
    public partial class File
    {
        public File()
        {
            InverseParent = new HashSet<File>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Size { get; set; }
        public int? ParentId { get; set; }
        public int CommitId { get; set; }

        public virtual Commit Commit { get; set; }
        public virtual File Parent { get; set; }
        public virtual ICollection<File> InverseParent { get; set; }
    }
}
