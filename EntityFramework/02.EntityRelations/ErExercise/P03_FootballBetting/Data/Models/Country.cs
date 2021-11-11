﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        // collection towns

        public ICollection<Town> Towns { get; set; }
    }
}