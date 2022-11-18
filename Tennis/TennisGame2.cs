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
            var score = "";

            // For Equal scores
            if (p1point == p2point && p1point < 3)
            {
                if (p1point == 0)
                    score = "Love";
                if (p1point == 1)
                    score = "Fifteen";
                if (p1point == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (p1point == p2point && p1point > 2)
                score = "Deuce";

            // For Normal scores
            if (p1point > 0 && p2point == 0)
            {
                if (p1point == 1)
                    p1res = "Fifteen";
                if (p1point == 2)
                    p1res = "Thirty";
                if (p1point == 3)
                    p1res = "Forty";

                p2res = "Love";
                score = p1res + "-" + p2res;
            }
            if (p2point > 0 && p1point == 0)
            {
                if (p2point == 1)
                    p2res = "Fifteen";
                if (p2point == 2)
                    p2res = "Thirty";
                if (p2point == 3)
                    p2res = "Forty";

                p1res = "Love";
                score = p1res + "-" + p2res;
            }

            if (p1point > p2point && p1point < 4)
            {
                if (p1point == 2)
                    p1res = "Thirty";
                if (p1point == 3)
                    p1res = "Forty";
                if (p2point == 1)
                    p2res = "Fifteen";
                if (p2point == 2)
                    p2res = "Thirty";
                score = p1res + "-" + p2res;
            }
            if (p2point > p1point && p2point < 4)
            {
                if (p2point == 2)
                    p2res = "Thirty";
                if (p2point == 3)
                    p2res = "Forty";
                if (p1point == 1)
                    p1res = "Fifteen";
                if (p1point == 2)
                    p1res = "Thirty";
                score = p1res + "-" + p2res;
            }

            // For Has advantage
            if (p1point > p2point && p2point >= 3)
            {
                score = $"Advantage {player1Name}";
            }

            if (p2point > p1point && p1point >= 3)
            {
                score = $"Advantage {player2Name}";
            }

            // For Has a winner
            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = $"Win for {player1Name}";
            }
            if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
            {
                score = $"Win for {player2Name}";
            }

            return score;
        }

    }
}

