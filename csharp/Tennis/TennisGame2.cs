namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _player1Points;
        private int _player2Points;

        private string _p1Res = "";
        private string _p2Res = "";
        public string Player1Name { get; }
        public string Player2Name { get; }

        public TennisGame2(string player1Name, string player2Name)
        {
            Player1Name = player1Name;
            Player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            if (_player1Points == _player2Points && _player1Points < 3)
            {
                if (_player1Points == 0)
                    score = "Love";
                if (_player1Points == 1)
                    score = "Fifteen";
                if (_player1Points == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (_player1Points == _player2Points && _player1Points > 2)
                score = "Deuce";

            if (_player1Points > 0 && _player2Points == 0)
            {
                if (_player1Points == 1)
                    _p1Res = "Fifteen";
                if (_player1Points == 2)
                    _p1Res = "Thirty";
                if (_player1Points == 3)
                    _p1Res = "Forty";

                _p2Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }
            if (_player2Points > 0 && _player1Points == 0)
            {
                if (_player2Points == 1)
                    _p2Res = "Fifteen";
                if (_player2Points == 2)
                    _p2Res = "Thirty";
                if (_player2Points == 3)
                    _p2Res = "Forty";

                _p1Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            if (_player1Points > _player2Points && _player1Points < 4)
            {
                if (_player1Points == 2)
                    _p1Res = "Thirty";
                if (_player1Points == 3)
                    _p1Res = "Forty";
                if (_player2Points == 1)
                    _p2Res = "Fifteen";
                if (_player2Points == 2)
                    _p2Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }
            if (_player2Points > _player1Points && _player2Points < 4)
            {
                if (_player2Points == 2)
                    _p2Res = "Thirty";
                if (_player2Points == 3)
                    _p2Res = "Forty";
                if (_player1Points == 1)
                    _p1Res = "Fifteen";
                if (_player1Points == 2)
                    _p1Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }

            if (_player1Points > _player2Points && _player2Points >= 3)
            {
                score = "Advantage player1";
            }

            if (_player2Points > _player1Points && _player1Points >= 3)
            {
                score = "Advantage player2";
            }

            if (_player1Points >= 4 && _player2Points >= 0 && (_player1Points - _player2Points) >= 2)
            {
                score = "Win for player1";
            }
            if (_player2Points >= 4 && _player1Points >= 0 && (_player2Points - _player1Points) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                _player1Points++;
            else
               _player2Points++;
        }

    }
}

