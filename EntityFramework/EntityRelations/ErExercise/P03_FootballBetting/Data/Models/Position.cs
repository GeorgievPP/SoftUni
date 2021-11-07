﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Name { get; set; }

        // collecton players
        public ICollection<Player> Players { get; set; }

    }
}
