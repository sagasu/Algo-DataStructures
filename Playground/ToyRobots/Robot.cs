namespace ToyRobots
{
    class Robot
    {
        public Position Position { get; set; }
        public ICardinalEngine CardinalEngine { get; set; }

        public Position GetMoveProjection()
        {
            return CardinalEngine.Move(Position);
        }

        public void Move()
        {
            Position = CardinalEngine.Move(Position);
        }

        public void TurnLeft()
        {
            CardinalEngine = CardinalEngine.GetLeftEngine();
        }

        public void TurnRight()
        {
            CardinalEngine = CardinalEngine.GetRightEngine();
        }

        public override string ToString()
        {
            return $"X:{Position.X}, Y:{Position.Y}, Cardinal Orientation:{CardinalEngine.CardinalDirection}";
        }
    }
}
