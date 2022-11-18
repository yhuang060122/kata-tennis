namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private readonly string player1Name;
        private readonly string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == this.player1Name)
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score;
            if (m_score1 == m_score2)
            {
                score = GetEqualScore(m_score1);
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                score = GetWinnerOrAdvantageScore(m_score1, m_score2);
            }
            else
            {
                score = GetNomalScore(m_score1, m_score2);
            }
            return score;
        }

        private static string GetNomalScore(int m_score1, int m_score2)
        {
            string score = "";
            for (var i = 1; i < 3; i++)
            {
                int tempScore;
                if (i == 1) tempScore = m_score1;
                else { score += "-"; tempScore = m_score2; }
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                    default:
                        break;
                }
            }

            return score;
        }

        private static string GetWinnerOrAdvantageScore(int m_score1, int m_score2)
        {
            string score;
            var minusResult = m_score1 - m_score2;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        private static string GetEqualScore(int m_score)
        {
            string score = m_score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
            return score;
        }


    }
}

