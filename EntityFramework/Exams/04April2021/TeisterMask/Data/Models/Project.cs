﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Common;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public DateTime OpenDate { get; set; }
        
        public DateTime? DueDate { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

    }
}

/*
 •	Id - integer, Primary Key
•	Name - text with length [2, 40] (required)
•	OpenDate - date and time (required)
•	DueDate - date and time (can be null)
•	Tasks - collection of type Task

 */
