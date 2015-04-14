using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class RollScorer
    {
        private string _rolls;
        public RollScorer(string rolls)
        {
            _rolls = rolls;
        }

        public int GetScore()
        {
            
            int accumulator = 0;
            var tokenizedRolls = _rolls.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < 10; i++ )
            {
                var rollScore = ScoreRoll(tokenizedRolls, i);
                accumulator += rollScore;
            }

            return accumulator;
        }

        private static int ScoreRoll(string[] tokenizedRolls, int i)
        {
            
            if (tokenizedRolls[i].IsStrike())
                return ScoreStrikeBonus(tokenizedRolls, i);
            if (tokenizedRolls[i].IsSpare())
                return ScoreSpareBonus(tokenizedRolls, i);
            return GetRawRollScore(tokenizedRolls, i);
        }

        private static int ScoreSpareBonus(string[] tokenizedRolls, int i)
        {
            return  GetRawRollScore(tokenizedRolls, i) +
                    GetRawRollScore(tokenizedRolls, i + 1);
        }

        private static int GetRawRollScore(string[] tokenizedRolls, int i)
        {
            
            if (i >= tokenizedRolls.Length)
                return 0;
            if (tokenizedRolls[i].IsStrike())
                return 10;
            if (tokenizedRolls[i].IsSpare())
                return 10;
            return ScoreStandardRoll(tokenizedRolls[i]);
            
        }

        private static int ScoreStandardRoll(string roll)
        {
            int accumulator = 0;
            foreach (char c in roll)
            {
                int result = 0;
                if(int.TryParse(c.ToString(), out result))
                    accumulator += result;
            }
            
            return accumulator;
        }

        private static int ScoreStrikeBonus(string[] tokenizedRolls, int i)
        {
            return 
                GetRawRollScore(tokenizedRolls, i) +
                GetRawRollScore(tokenizedRolls, i + 1) +
                GetRawRollScore(tokenizedRolls, i + 2);
                
        }
    }

    public static class StringExtensions {
        public static bool IsStrike(this string x) {
            return x == "X";
        }

        public static bool IsSpare(this string x)
        {
            return x[1] == '/';
        }
    }
}
