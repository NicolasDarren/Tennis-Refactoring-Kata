using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        public string Player1Name { get; }
        public string Player2Name { get; }

        private int _player1Points;
        private int _player2Points;

        public TennisGame2(string player1Name, string player2Name)
        {
            Player1Name = player1Name;
            Player2Name = player2Name;
        }
        
        public string GetScore()
        {
            var pointGap = Math.Abs(_player1Points - _player2Points);

            if (pointGap == 0 && _player1Points > 2)
                return "Deuce";

            if (_player1Points >= 4 || _player2Points >= 4)
            {
                var player1HasMorePoints = _player1Points > _player2Points;
                return pointGap >= 2 
                    ? GetWinningScore(player1HasMorePoints) 
                    : GetAdvantageScore(player1HasMorePoints);
            }

            var score = GetPlayerScore(_player1Points) + "-";
            if (_player1Points == _player2Points) return score + "All";

            return score + GetPlayerScore(_player2Points);
        }

        private static string GetWinningScore(bool player1HasMorePoints)
        {
            return player1HasMorePoints ? "Win for player1" : "Win for player2";
        }

        private static string GetAdvantageScore(bool player1HasMorePoints)
        {
            return player1HasMorePoints ? "Advantage player1" : "Advantage player2";
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                _player1Points++;
            else
                _player2Points++;
        }

        private string GetPlayerScore(int playerPoints)
        {
            return playerPoints switch
                {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty",
                };
        }
    }
}
