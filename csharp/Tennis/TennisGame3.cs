namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        public string Player1Name { get; }
        public string Player2Name { get; }
        private readonly string[] _possibleScores = {"Love", "Fifteen", "Thirty", "Forty"};
        private int _player2Points;
        private int _player1Points;

        public TennisGame3(string player1Name, string player2Name)
        {
            Player1Name = player1Name;
            Player2Name = player2Name;
        }

        public string GetScore()
        {
            if (_player1Points < 4 && _player2Points < 4 && _player1Points + _player2Points < 6)
            {
                var score = _possibleScores[_player1Points];
                return _player1Points == _player2Points 
                    ? score + "-All" 
                    : score + "-" + _possibleScores[_player2Points];
            }

            if (_player1Points == _player2Points)
                return "Deuce";

            var playerWithMostPoints = GetPlayerWithMostPoints();
            return (_player1Points - _player2Points) * (_player1Points - _player2Points) == 1 
                ? "Advantage " + playerWithMostPoints
                : "Win for " + playerWithMostPoints;
        }

        private string GetPlayerWithMostPoints()
        {
            return _player1Points > _player2Points ? Player1Name : Player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Points += 1;
            else
                _player2Points += 1;
        }
    }
}

