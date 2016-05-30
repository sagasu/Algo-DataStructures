using System;

namespace Playground.Robot
{
    class Simulator
    {
        private readonly Board _board;
        private readonly Robot _robot;

        public Simulator() : this(new Board(), new Robot()){}

        public Simulator(Board board, Robot robot)
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
