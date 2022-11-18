using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int p2Pts;
        private int p1Pts;
        private readonly string p1Name;
        private readonly string p2Name;
        private static readonly string[] simpleScores = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            this.p1Name = player1Name;
            this.p2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == p1Name)
                this.p1Pts += 1;
            else
                this.p2Pts += 1;
        }

        public string GetScore()
        {
            if (IsNoPlayerFourWinsOrDeuce)
            {
                return (IsEqualScore) 
                    ? $"{simpleScores[p1Pts]}-All" 
                    : $"{simpleScores[p1Pts]}-{simpleScores[p2Pts]}";
            }
            else
            {
                if (IsEqualScore)
                    return "Deuce";

                var pName = p1Pts > p2Pts ? p1Name : p2Name;
                return (Math.Abs(p1Pts - p2Pts) == 1) 
                    ? $"Advantage {pName}" 
                    : $"Win for {pName}";
            }
        }

        private bool IsEqualScore => p1Pts == p2Pts;
        private bool IsNoPlayerFourWinsOrDeuce => (p1Pts < 4 && p2Pts < 4) && (p1Pts + p2Pts < 6);
    }
}

