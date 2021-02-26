using System;

namespace Tennis
{
    internal class TennisGame1 : ITennisGame
    {
        private string player1Name;
        private int player1Points;
        private string player2Name;
        private int player2Points;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Points += 1;
            else
                player2Points += 1;
        }

        public string GetScore()
        {
            var score = "";
            if (player1Points == player2Points)
            {
                return GetScoreWhenEqualPoints();
            }

            if (player1Points >= 4 || player2Points >= 4)
            {
                var pointGap = player1Points - player2Points;
                return PointGapIsMoreThanOne(pointGap)
                    ? GetWinningScore(pointGap)
                    : GetAdvantageScore(pointGap);
            }

            for (var i = 1; i < 3; i++)
            {
                var tempScore = 0;
                if (i == 1)
                {
                    tempScore = player1Points;
                }
                else
                {
                    score += "-";
                    tempScore = player2Points;
                }

                score = GetPlayerGameScore(tempScore, score);
            }

            return score;
        }

        private static string GetPlayerGameScore(int tempScore, string score)
        {
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
            }

            return score;
        }

        private static bool PointGapIsMoreThanOne(int minusResult)
        {
            return Math.Abs(minusResult) >= 2;
        }

        private static string GetAdvantageScore(int minusResult)
        {
            return minusResult == 1 ? "Advantage player1" : "Advantage player2";
        }

        private static string GetWinningScore(int minusResult)
        {
            return minusResult >= 2 ? "Win for player1" : "Win for player2";
        }

        private string GetScoreWhenEqualPoints()
        {
            string score;
            switch (player1Points)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }

            return score;
        }
    }
}