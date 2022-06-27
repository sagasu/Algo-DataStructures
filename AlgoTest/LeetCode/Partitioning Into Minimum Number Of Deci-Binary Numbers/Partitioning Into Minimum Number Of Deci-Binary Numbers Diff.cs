using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Partitioning_Into_Minimum_Number_Of_Deci_Binary_Numbers
{
    [TestClass]
    public class Partitioning_Into_Minimum_Number_Of_Deci_Binary_NumbersDiff
    {

        public int MinPartitions(string n)
        {
            return n.Select(x => int.Parse(x.ToString())).Max();
        }
    }
}
