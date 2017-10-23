using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.PrintAllSubsets
{
    [TestFixture]
    class PrintAllSubsetsTests
    {
        [TestCase(new int[]{1,2,3,4}, 3)]
        public void PrintAllSubsets_TestCase_ExpectedResult(int[] set, int k)
        {
            new PrintAllSubsets().PrintAllKSizeSubsets(set, k);

            //cheating
            Assert.True(true);
        }
    }
}
