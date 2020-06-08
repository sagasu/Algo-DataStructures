using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.SpiralMatrix
{
    [TestClass]
    public class SpiralMatrix
    {
        [TestMethod]
        public void TesT()
        {
            var t = new int[][]
            {
                new int[]{ 1, 2, 3 },
                new int[]{ 4, 5, 6 },
                new int[]{ 7, 8, 9 }
            };
            var res = SpiralOrder(t);
        }

        enum direction
        {
            up,
            right,
            down,
            left
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 1)
                return matrix[0];
            if (matrix.Length == 0)
                return new List<int>();

            var ret = new List<int>();
            var up = 0;
            var right= matrix[0].Length-1;
            var down = matrix.Length-1;
            var left = 0;
            var index = new int[]{ 0, 0 };
            direction dir = direction.right;
            var isChange = false;
            while (true)
            {
                if (right == left && up == down)
                    break;

                if (!isChange)
                {
                    ret.Add(matrix[index[0]][index[1]]);
                }
                
                switch (dir)
                {
                    case direction.right:
                        if (index[1] == right)
                        {
                            right -= 1;
                            dir = direction.down;
                            isChange = true;
                        }
                        else
                        {
                            index[1] += 1;
                            isChange = false;
                        }

                        break;
                    case direction.down:
                        if (index[0] == down)
                        {
                            down -= 1;
                            dir = direction.left;
                            isChange = true;
                        }
                        else
                        {
                            index[0] += 1;
                            isChange = false;
                        }

                        break;
                    case direction.left:
                        if (index[1] == left)
                        {
                            left += 1;
                            dir = direction.up;
                            isChange = true;
                        }
                        else
                        {
                            index[1] -= 1;
                            isChange = false;
                        }

                        break;
                    case direction.up:
                        if (index[0] == up)
                        {
                            up += 1;
                            dir = direction.right;
                            isChange = true;
                        }
                        else
                        {
                            index[0] -= 1;
                            isChange = false;
                        }

                        break;
                }
                
            }

            return ret;
        }
    }
}
