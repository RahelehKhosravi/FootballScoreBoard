using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LiveFootballScoreboard
{
    [TestClass]
    public class TestScoreboard
    {
        [TestMethod]
        // Test if start match/es added to the board
        public void TestStartMatch()
        {
            var scoreboard = new Scoreboard();
            scoreboard.StartMatch("Mexico", "Canada");
            scoreboard.StartMatch("Spain", "Brazil");

            Assert.AreEqual(2, scoreboard.GetSummary().Count);
        }

        [TestMethod]
        // Test if match/es on the board updated
        public void TestUpdateScore()
        {
            var scoreboard = new Scoreboard();
            scoreboard.StartMatch("Mexico", "Canada");
            scoreboard.UpdateScore("Mexico", "Canada", 0, 5);

            var match = scoreboard.GetSummary().First();
            Assert.AreEqual(5, match.AwayScore);
        }

        [TestMethod]
        // Test if finished match/es removed from the board 
        public void TestFinishMatch()
        {
            var scoreboard = new Scoreboard();
            scoreboard.StartMatch("Mexico", "Canada");
            scoreboard.StartMatch("Spain", "Brazil");
            scoreboard.FinishMatch("Mexico", "Canada");

            Assert.AreEqual(1, scoreboard.GetSummary().Count);
        }

        [TestMethod]
        // Test if we have all on going match/es on the board in order 
        public void TestGetSummary()
        {
            var scoreboard = new Scoreboard();

            // Start matches
            scoreboard.StartMatch("Mexico", "Canada");
            scoreboard.StartMatch("Spain", "Brazil");
            scoreboard.StartMatch("Germany", "France");
            scoreboard.StartMatch("Uruguay", "Italy");
            scoreboard.StartMatch("Argentina", "Australia");

            // Update scores
            scoreboard.UpdateScore("Mexico", "Canada", 0, 5);
            scoreboard.UpdateScore("Spain", "Brazil", 10, 2);
            scoreboard.UpdateScore("Germany", "France", 2, 2);
            scoreboard.UpdateScore("Uruguay", "Italy", 6, 6);
            scoreboard.UpdateScore("Argentina", "Australia", 3, 1);

            var summary = scoreboard.GetSummary();

            // check the Scoreboard output order
            Assert.AreEqual("Uruguay", summary[0].HomeTeam);
            Assert.AreEqual("Spain", summary[1].HomeTeam);
            Assert.AreEqual("Mexico", summary[2].HomeTeam);
            Assert.AreEqual("Argentina", summary[3].HomeTeam);
            Assert.AreEqual("Germany", summary[4].HomeTeam);
        }
    }
}
