using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"^\d{4}\ \d{4}\ \d{4} \d{4}$")] // /s   i na dr mes
        public string Number { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        [RegularExpression(@"^\d{3}?")]
        public string CVC { get; set; }
        
        [Range(0, 1)]
        public string Type { get; set; }

    }
}

/*
 •	Id – integer, Primary Key
•	Number – text, which consists of 4 pairs of 4 digits, separated by spaces (ex. “1234 5678 9012 3456”) (required)
•	Cvc – text, which consists of 3 digits (ex. “123”) (required)
•	Type – enumeration of type CardType, with possible values (“Debit”, “Credit”) (required)
•	UserId – integer, foreign key (required)
•	User – the card’s user (required)
•	Purchases – collection of type Purchase
 */

/*
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

 */
