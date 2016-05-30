using System.Collections.Generic;

namespace ToyRobots
{
    interface ICardinalEngine
    {
        Position Move(Position position);
        ICardinalEngine GetLeftEngine();
        ICardinalEngine GetRightEngine();
        string CardinalDirection { get; }
    }

    internal static class Cardinal
    {
        public static IEnumerable<ICardinalEngine> GetAllCardinalEngines()
        {
            yield return new NorthEngine();
            yield return new SouthEngine();
            yield return new EastEngine();
            yield return new WestEngine();
        }
    }

    internal class NorthEngine : ICardinalEngine
    {
        public Position Move(Position position)
        {
            return new Position(position.X, position.Y + 1);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new WestEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new EastEngine();
        }

        public string CardinalDirection => "NORTH";
    }

    internal class SouthEngine : ICardinalEngine
    {
        public Position Move(Position position)
        {
            return new Position(position.X, position.Y - 1);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new EastEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new WestEngine();
        }

        public string CardinalDirection => "SOUTH";
    }

    internal class WestEngine : ICardinalEngine
    {
        public Position Move(Position position)
        {
            return new Position(position.X - 1, position.Y);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new SouthEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new NorthEngine();
        }

        public string CardinalDirection => "WEST";
    }

    internal class EastEngine : ICardinalEngine
    {
        public Position Move(Position position)
        {
            return new Position(position.X + 1, position.Y);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new NorthEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new SouthEngine();
        }

        public string CardinalDirection => "EAST";
    }


}
