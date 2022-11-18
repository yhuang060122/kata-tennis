using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point = 0;
        private int p2point = 0;

        private string p1res = "";
        private string p2res = "";
        private readonly string player1Name;
        private readonly string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string player)
        {
            if (player == player1Name)
                p1point++;
            else
                p2point++;
        }

        public string GetScore()
        {
            // For Equal scores
            string score = GetEqualScore();

            if (!string.IsNullOrEmpty(score))
                return score;

            // For Has a winner
            score = GetWinnerScore();

            if (!string.IsNullOrEmpty(score))
                return score;

            // For Has advantage
            score = GetAdvantageScore();

            if (!string.IsNullOrEmpty(score))
                return score;

            // For Normal scores
            score = GetNormalScore();

            return score;
        }

        private string GetNormalScore()
        {
            string getSimpleScore(int pt) => pt switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => "",
            };

            
            return getSimpleScore(p1point) + "-" + getSimpleScore(p2point);
        }

        private string GetWinnerScore()
        {
            string score = "";

            if (HasWinner)
            {
                score = p1point > p2point ? $"Win for {player1Name}" : $"Win for {player2Name}";
            }

            return score;
        }

        private string GetAdvantageScore()
        {
            string score = "";

            if (HasAdvantage)
            {
                if (p1point > p2point)
                {
                    score = $"Advantage {player1Name}";
                }
                else
                {
                    score = $"Advantage {player2Name}";
                }
            }

            return score;
        }

        private string GetEqualScore()
        {
            string score = "";
            if (IsEqualScore)
            {
                if (p1point < 3)
                {
                    score = p1point switch
                    {
                        0 => "Love",
                        1 => "Fifteen",
                        2 => "Thirty",
                        _ => "",
                    };
                    score += "-All";
                }
                else
                {
                    score = "Deuce";
                }
            }
            return score;
        }

        private bool IsEqualScore => p1point == p2point;

        private bool HasAdvantage => Math.Abs(p1point - p2point) == 1 && (p1point >= 4 || p2point >= 4);

        private bool HasWinner => Math.Abs(p1point - p2point) > 1 && (p1point >= 4 || p2point >= 4);
    }
}

