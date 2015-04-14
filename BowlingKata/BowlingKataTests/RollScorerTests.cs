using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingKata;
using NUnit.Framework;
namespace BowlingKata.Tests
{
    [TestFixture()]
    public class RollScorerTests
    {
        [Test()]
        public void RollScorerCanBeConstructed()
        {
            new RollScorer(string.Empty);
        }

        [Test]
        public void RollScoreHasScoreMethod()
        {
            var scorer = new RollScorer("-- -- -- -- -- -- -- -- -- --");
            int score = scorer.GetScore();
        }

        private int GetScore(string rolls) {
            var scorer = new RollScorer(rolls);
            return scorer.GetScore();
        }

        [Test]
        
        [TestCase("X  -- -- -- -- -- -- -- -- --", 10)]
        [TestCase("X  11 11 -- -- -- -- -- -- --",18)]
        [TestCase("X  X  X  -- -- -- -- -- -- --",60)]
        [TestCase("-- -- -- -- -- -- -- -- -- X  X  X", 30)]
        [TestCase("-- -- -- -- -- -- -- -- -- X  11  11", 14)]
        [TestCase("X X X X X X X X X X X X", 300)]
        public void StrikeGameGivesExpectedScore(string roll, int expectedScore)
        {
            Assert.That(GetScore(roll), Is.EqualTo(expectedScore));
        }

        [TestCase("-- -- -- -- -- -- -- -- -- --",0)]
        [TestCase("-- -- -- -- -- -- -- -- -- -- 55 55", 0)]
        [TestCase("1- -- -- -- -- -- -- -- -- --", 1)]
        [TestCase("11 -- -- -- -- -- -- -- -- --",2)]
        [TestCase("-1 -- -- -- -- -- -- -- -- --",1)]
        public void NumericGameGivesExpectedScore(string roll, int expectedScore)
        {
            Assert.That(GetScore(roll), Is.EqualTo(expectedScore));
        }

        [TestCase("5/ -- -- -- -- -- -- -- -- --", 10)]
        [TestCase("5/ 5- -- -- -- -- -- -- -- --", 20)]
        [TestCase("5/ -5 -- -- -- -- -- -- -- --", 20)]
        [TestCase("5/ -5 -5 -- -- -- -- -- -- --", 25)]
        [TestCase("-- -- -- -- -- -- -- -- -- 5/ -5", 15)]
        [TestCase("-- -- -- -- -- -- -- -- -- 5/ -5 -5", 15)]
        public void SpareGameGivesExpectedScore(string roll, int expectedScore)
        {
            Assert.That(GetScore(roll), Is.EqualTo(expectedScore));
        }
    }
}
