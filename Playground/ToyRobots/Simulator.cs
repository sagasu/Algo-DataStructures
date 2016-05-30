using System;

namespace ToyRobots
{
    class Simulator
    {
        private readonly Board _board;
        private readonly ToyRobots.Robot _robot;

        public Simulator() : this(new Board(), new ToyRobots.Robot()){}

        public Simulator(Board board, ToyRobots.Robot robot)
        {
            _board = board;
            _robot = robot;
        }

        public void Move()
        {
            if (_board.IsValidPosition(_robot.GetMoveProjection()))
            {
                _robot.Move();
            } else {
                Console.WriteLine("Sorry this move is illegal.");
            }
        }

        public void Left()
        {
            _robot.TurnLeft();
        }

        public void Right()
        {
            _robot.TurnRight();
        }

        public void Place(int x, int y, ICardinalEngine cardinalEngine)
        {
            _robot.Position = new Position(x,y);
            _robot.CardinalEngine = cardinalEngine;
        }

        public void Report()
        {
            Console.WriteLine(_robot.ToString());
        }
    }
}
