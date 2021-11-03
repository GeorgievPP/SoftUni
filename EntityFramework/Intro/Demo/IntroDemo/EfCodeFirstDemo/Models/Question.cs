using System;
using System.ComponentModel.DataAnnotations;

namespace EfCodeFirstDemo.Models
{
    public class Question
    { 
        public int Id { get; set; }


        [Required]
        [MaxLength (200)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
