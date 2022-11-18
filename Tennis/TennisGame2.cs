using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point = 0;
        private int p2point = 0;

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
            if (HasWinner)
            {
                return GetWinnerScore();
            }

            if (IsEqualScore)
            {
                return GetEqualScore();
            }

            if (HasAdvantage)
            {
                return GetAdvantageScore();
            }

            return GetNormalScore();
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
            return p1point > p2point ? $"Win for {player1Name}" : $"Win for {player2Name}";
        }

        private string GetAdvantageScore()
        {
            return p1point > p2point ? $"Advantage {player1Name}" : $"Advantage {player2Name}";
        }

        private string GetEqualScore()
        {
            string score;
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
            return score;
        }

        private bool IsEqualScore => DiffPoints == 0;

        private bool HasAdvantage => DiffPoints == 1 && HasPlayerAtLeastFourWins;

        private bool HasWinner => DiffPoints > 1 && HasPlayerAtLeastFourWins;

        private bool HasPlayerAtLeastFourWins => (p1point >= 4 || p2point >= 4);

        private int DiffPoints => Math.Abs(p1point - p2point);
    }
}

