using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(GlobalConstants.EMPLOYEE_USERNAME_REGEX)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [RegularExpression(GlobalConstants.EMPLOYEE_PHONE_REGEX)]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }

    }
}

/*
 * •	Id - integer, Primary Key
•	Username - text with length [3, 40]. Should contain only lower or upper case letters and/or digits. (required)
•	Email – text (required). Validate it! There is attribute for this job.
•	Phone - text. Consists only of three groups (separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required)
•	EmployeesTasks - collection of type EmployeeTask
 */
/*
 [
  {
    "Username": "jstanett0",
    "Email": "kknapper0@opera.com",
    "Phone": "819-699-1096",
    "Tasks": [
      34,
      32,
      65,
      30,
      30,
      45,
      36,
      67
    ]
  },
  ...
]

 */