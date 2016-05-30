namespace Playground.Robot
{
    interface ICardinalEngine
    {
        Position Move(Position position);
        ICardinalEngine GetLeftEngine();
        ICardinalEngine GetRightEngine();
        string CardinalDirection { get; }
    }

    internal class NorthEngine : ICardinalEngine
    {
        public Position Move(Position position)
        {
            return new Position(position.X, position.Y++);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new EastEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new WestEngine();
        }

        public string CardinalDirection => "North";
    }

    internal class SouthEngine : ICardinalEngine
    {
        public Position Move(Position position)
        {
            return new Position(position.X, position.Y--);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new EastEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new WestEngine();
        }

        public string CardinalDirection => "South";
    }

    internal class WestEngine : ICardinalEngine
    {
        public Position Move(Position position)
        {
            return new Position(position.X--, position.Y);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new SouthEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new NorthEngine();
        }

        public string CardinalDirection => "West";
    }

    internal class EastEngine : ICardinalEngine
    {
        public Position Move(Position position)
        {
            return new Position(position.X++, position.Y);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new NorthEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new SouthEngine();
        }

        public string CardinalDirection => "East";
    }


}
