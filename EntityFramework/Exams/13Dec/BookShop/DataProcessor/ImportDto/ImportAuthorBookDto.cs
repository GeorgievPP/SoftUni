using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorBookDto
    {
        [JsonProperty("Id")]
        public int? BookId { get; set; }
    }
}

/*
  {
    "FirstName": "K",
    "LastName": "Tribbeck",
    "Phone": "808-944-5051",
    "Email": "btribbeck0@last.fm",
    "Books": [
      {
        "Id": 79
      },
      {
        "Id": 40
      }
    ]
  }
 */
