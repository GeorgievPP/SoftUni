using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")] // tyka
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        [MaxLength(1)]
        public ImportCardDto[] Cards { get; set; }

    }
}

/*
 •	Id – integer, Primary Key
•	Username – text with length [3, 20] (required)
•	FullName – text, which has two words, consisting of Latin letters. Both start with an upper letter and are followed by lower letters. The two words are separated by a single space (ex. "John Smith") (required)
•	Email – text (required)
•	Age – integer in the range [3, 103] (required)
•	Cards – collection of type Card

 */

/* {
    "FullName": "Lorrie Silbert",
    "Username": "lsilbert",
    "Email": "lsilbert@yahoo.com",
    "Age": 33,
    "Cards": [
      {
        "Number": "1833 5024 0553 6211",
        "CVC": "903",
        "Type": "Debit"
      },
      {
        "Number": "5625 0434 5999 6254",
        "CVC": "570",
        "Type": "Credit"
      },
      {
        "Number": "4902 6975 5076 5316",
        "CVC": "091",
        "Type": "Debit"
      }
    ]
  },

*/
