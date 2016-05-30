namespace ToyRobots
{
    internal class Board
    {
        private readonly int _boardHight;
        private readonly int _boardWidth;

        public Board()
        {
            _boardWidth = 4;
            _boardHight = 4;
        }

        public bool IsValidPosition(Position position)
        {
            return position.X >= 0 && position.X < _boardHight &&
                   position.Y >= 0 && position.Y < _boardWidth;
        }
    }
}