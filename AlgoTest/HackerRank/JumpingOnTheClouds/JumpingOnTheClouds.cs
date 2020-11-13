using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.HackerRank.JumpingOnTheClouds
{
    [TestClass]
    public class JumpingOnTheClouds
    {
        [TestMethod]
        public void JumpingOnTheCloudsTest()
        {
            //6
            var clouds = new int[] {0, 0, 0, 0, 1, 0};
            Assert.AreEqual(3,GetShortestJumpNumber(clouds));
        }

        public int GetShortestJumpNumber(int[] c)
        {
            if (c.Length == 0)
                return 0;
            var index = 0;
            var jumps = 0;
            while (true)
            {
                if (index + 2 < c.Length && c[index + 2] != 1)
                {
                    index += 2;
                    jumps += 1;
                }else if (index + 1 < c.Length)
                {
                    index += 1;
                    jumps += 1;
                }
                else
                {
                    return jumps;
                }
                
            }
        }
    }
}
