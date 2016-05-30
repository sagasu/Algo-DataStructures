using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ToyRobots
{
    class CommandLineManager
    {
        private const string PLACE_COMMAND_NAME = "PLACE";

        private readonly IDictionary<string, Expression<Action<string>>> _validOperations = new Dictionary
            <string, Expression<Action<string>>>();

        private readonly Simulator _simulator;

        public CommandLineManager()
        {
            _simulator = new Simulator();

            _validOperations.Add(PLACE_COMMAND_NAME, (args) => Place(args));
            _validOperations.Add("REPORT", (_) => _simulator.Report());
            _validOperations.Add("MOVE", (_) => _simulator.Move());
            _validOperations.Add("LEFT", (_) => _simulator.Left());
            _validOperations.Add("RIGHT", (_) => _simulator.Right());
        }
        
        public void Run()
        {
            string inputCommand;
            var isPlaceExecuted = false;

            while (!string.IsNullOrEmpty(inputCommand = Console.ReadLine()))
            {
                var commandWithArgs = inputCommand.ToUpper().Split(' ');
                var command = commandWithArgs.First();

                if (!_validOperations.ContainsKey(command))
                {
                    Console.WriteLine("Sorry, unknown command: " + command);
                    continue;
                }

                if (!isPlaceExecuted && command != PLACE_COMMAND_NAME)
                {
                    Console.WriteLine("Sorry, first command has to be: " + PLACE_COMMAND_NAME);
                    continue;
                }

                
                var commandArgs = commandWithArgs.Skip(1);
                _validOperations[command].Compile().Invoke(string.Concat(commandArgs));
                isPlaceExecuted = true;
            }
        }

        //parsing args that should be in following format X,Y,CARDINAL
        private void Place(string commandArgs)
        {
            var args = commandArgs.Split(',');
            if (args.Length != 3)
            {
                Console.WriteLine("Sorry correct format of PLACE command is following: PLACE X,Y,CARDINAL");
                return;
            }

            var cardinalEngine =
                Cardinal.GetAllCardinalEngines()
                        .FirstOrDefault(caEngine => args[2] == caEngine.CardinalDirection);

            if (cardinalEngine == null)
            {
                Console.WriteLine("Sorry incorrect CARDINAL. Available values: " +
                    string.Join(", ", Cardinal.GetAllCardinalEngines().Select(_ => _.CardinalDirection)));
                return;
            }

            var coordinateX = int.Parse(args[0]);
            var coordinateY = int.Parse(args[1]);
            _simulator.Place(coordinateX, coordinateY, cardinalEngine);
        }
    }
}
