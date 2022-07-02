using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_Area_of_a_Piece_of_Cake_After_Horizontal_and_Vertical_Cuts
{
    internal class Maximum_Area_of_a_Piece_of_Cake_After_Horizontal_and_Vertical_Cuts
    {
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) => (int)(((long)
                horizontalCuts.OrderBy(c => c).Prepend(0).Zip(horizontalCuts.OrderBy(c => c).Append(h), (f, s) => s - f).Max() *
                verticalCuts.OrderBy(c => c).Prepend(0).Zip(verticalCuts.OrderBy(c => c).Append(w), (f, s) => s - f).Max()
            ) % 1000000007);
    }
}
