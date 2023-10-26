﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LiveFootballScoreboard
{
    // Scoreboard Match
    public class Match
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool IsFinished { get; set; }
    }
}
