using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Poor_Pigs
{
    internal class Poor_Pigs
    {
        public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
        {
            var i = minutesToTest / minutesToDie + 1;
            return (int)Math.Ceiling(Math.Log(buckets, i));
        }
    }
}
