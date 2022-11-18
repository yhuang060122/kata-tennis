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
            if (IsEqualScore)
                return GetEqualScore(m_score1);

            if (HasWinnerOrAdvantage)
                return GetWinnerOrAdvantageScore(m_score1, m_score2);

            return GetNomalScore(m_score1, m_score2);
        }

        private bool IsEqualScore => m_score1 == m_score2;
        private bool HasWinnerOrAdvantage => m_score1 >= 4 || m_score2 >= 4;

        private static string GetNomalScore(int m_score1, int m_score2)
        {
            return GetSimpleScore(m_score1) + "-" + GetSimpleScore(m_score2);
        }

        private static string GetSimpleScore(int m_score)
        {
            return m_score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => "",
            };
        }

        private static string GetWinnerOrAdvantageScore(int m_score1, int m_score2)
        {
            var minusResult = m_score1 - m_score2;
            return minusResult switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2",
            };
        }

        private static string GetEqualScore(int m_score)
        {
            return m_score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
        }


    }
}

