using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Robot
{
    class CommandLineExecutor
    {
        Simulator _simulator = new Simulator();
        private IDictionary<string, Expression<Action<string>>> validOperations = new Dictionary
            <string, Expression<Action<string>>>()
        {
            { "Place", (x) => _simulator.Place(1, 2, new EastEngine()) }
        }
    }
}
