using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Playground.Robot
{
    class ToyRobot
    {
        private static IDictionary<string, Expression<Action<string>>> validOperations = new Dictionary
            <string, Expression<Action<string>>>();

        public static void Main(string[] args) {
            Simulator _simulator = new Simulator();

            validOperations.Add("PLACE", (x) => _simulator.Place(1, 2, new EastEngine()) );
            validOperations.Add("REPORT", (x) => _simulator.Report() );
            validOperations.Add("MOVE", (x) => _simulator.Move() );
            validOperations.Add("LEFT", (x) => _simulator.Left() );
            validOperations.Add("RIGHT", (x) => _simulator.Right() );

            string inputCommand;
            while (string.IsNullOrEmpty(inputCommand = Console.ReadLine()))
            {
                var command = inputCommand.Split(' ');
                if(validOperations.ContainsKey(command.First()))
                {
                    validOperations[command.First()].Compile().Invoke(string.Concat(command.Skip(1)));
                }
            }
            
        }
    }
}
