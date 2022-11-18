namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int p2Pts;
        private int p1Pts;
        private readonly string p1Name;
        private readonly string p2Name;

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
            string score;
            if ((p1Pts < 4 && p2Pts < 4) && (p1Pts + p2Pts < 6))
            {
                string[] simpleScores = { "Love", "Fifteen", "Thirty", "Forty" };
                score = simpleScores[p1Pts];
                return (p1Pts == p2Pts) ? score + "-All" : score + "-" + simpleScores[p2Pts];
            }
            else
            {
                if (p1Pts == p2Pts)
                    return "Deuce";
                score = p1Pts > p2Pts ? p1Name : p2Name;
                return ((p1Pts - p2Pts) * (p1Pts - p2Pts) == 1) ? "Advantage " + score : "Win for " + score;
            }
        }

    }
}

