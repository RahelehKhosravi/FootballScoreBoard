using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveFootballScoreboard
{
    //Live Football World Cup Scoreboard that shows all the ongoing matches and their scores.
    public class Scoreboard
    {
        private Dictionary<string, Match> matches = new Dictionary<string, Match>();

        //Add match/es to the board with the initial score assumption
        public void StartMatch(string homeTeam, string awayTeam)
        {
            string matchKey = $"{homeTeam} vs. {awayTeam}";
            if (!matches.ContainsKey(matchKey))
            {
                var match = new Match
                {
                    HomeTeam = homeTeam,
                    AwayTeam = awayTeam,
                    HomeScore = 0,
                    AwayScore = 0,
                };
                matches[matchKey] = match;
            }
        }

        //Update scores on the board
        public void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore)
        {
            string matchKey = $"{homeTeam} vs. {awayTeam}";
            if (matches.ContainsKey(matchKey) && !matches[matchKey].IsFinished)
            {
                matches[matchKey].HomeScore = homeScore;
                matches[matchKey].AwayScore = awayScore;
            }
        }

        //Update board with ongoing match/es and not the finished one/s anymore
        public void FinishMatch(string homeTeam, string awayTeam)
        {
            string matchKey = $"{homeTeam} vs. {awayTeam}";
            if (matches.ContainsKey(matchKey) && !matches[matchKey].IsFinished)
            {
                matches[matchKey].IsFinished = true;
            }
        }

        //Get all ongoing matches
        public List<Match> GetSummary()
        {
            var sortedMatches = matches.Values
            .Where(match => !match.IsFinished)
            .OrderByDescending(match => match.HomeScore + match.AwayScore)
            .ThenByDescending(match => matches.Values.ToList().IndexOf(match))
            .ToList();

            return sortedMatches;
        }
    }
}
