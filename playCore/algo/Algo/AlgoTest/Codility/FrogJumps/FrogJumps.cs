using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.Codility.FrogJumps
{
    class FrogJumps
    {
        public int solution(int X, int Y, int D)
        {
            var distanceDiff = (Y - X);
            var nrOfJumps = distanceDiff / D;
            return distanceDiff % D == 0 ? nrOfJumps : nrOfJumps + 1;
        }
    }
}
