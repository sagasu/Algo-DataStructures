using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.UTF_8_Validation
{
    internal class UTF_8_Validation
    {
        public bool ValidUtf8(int[] data)
        {
            var bytesLeft = 0;
            foreach (var num in data)
            {
                if (bytesLeft == 0)
                {
                    if (num >> 7 == 0b0) bytesLeft = 0;
                    else if (num >> 5 == 0b110) bytesLeft = 1;
                    else if (num >> 4 == 0b1110) bytesLeft = 2;
                    else if (num >> 3 == 0b11110) bytesLeft = 3;
                    else return false;
                }
                else
                {
                    if (num >> 6 == 0b10) bytesLeft--;
                    else return false;
                }
            }

            return bytesLeft == 0;
        }
    }
}
