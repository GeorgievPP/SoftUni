﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeisterMask.Common;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models
{
    public class Task
    {
        public Task()
        {
            this.EmployeesTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        
        public DateTime OpenDate { get; set; }

        public DateTime DueDate { get; set; }

        public ExecutionType ExecutionType { get; set; }

        public LabelType LabelType { get; set; }


        [ForeignKey(nameof(Project))] 
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }


        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }

    }
}

/*
 •	Id - integer, Primary Key
•	Name - text with length [2, 40] (required)
•	OpenDate - date and time (required)
•	DueDate - date and time (required)
•	ExecutionType - enumeration of type ExecutionType, with possible values (ProductBacklog, SprintBacklog, InProgress, Finished) (required)
•	LabelType - enumeration of type LabelType, with possible values (Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) (required)
•	ProjectId - integer, foreign key (required)
•	Project - Project 
•	EmployeesTasks - collection of type EmployeeTask

 */