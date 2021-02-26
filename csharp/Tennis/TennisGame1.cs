using System;

namespace Tennis
{
    internal class TennisGame1 : ITennisGame
    {
        public string Player1Name { get; }
        public string Player2Name { get; }
        private int _player1Points;
        private int _player2Points;

        public TennisGame1(string player1Name, string player2Name)
        {
            Player1Name = player1Name;
            Player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
          if (playerName == "player1")
            _player1Points += 1;
          else
            _player2Points += 1;
        }

        public string GetScore()
        {
            if (PointsAreEqual())
            {
                return GetScoreWhenPointsAreEqual();
            }

            if (_player1Points >= 4 || _player2Points >= 4)
            {
                var pointGap = _player1Points - _player2Points;
                return PointGapIsMoreThanOne(pointGap)
                    ? GetWinningScore(pointGap)
                    : GetAdvantageScore(pointGap);
            }

            return $"{GetPlayerGameScore(_player1Points)}-{GetPlayerGameScore(_player2Points)}";
        }

        private bool PointsAreEqual()
        {
          return _player1Points == _player2Points;
        }

        private static string GetPlayerGameScore(int points)
        {
          return points switch
          {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            _ => "Forty"
          };
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

        private string GetScoreWhenPointsAreEqual()
        {
          return _player1Points < 3 
            ? $"{GetPlayerGameScore(_player1Points)}-All" 
            : "Deuce";
        }
    }
}