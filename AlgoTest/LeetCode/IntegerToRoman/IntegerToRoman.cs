using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.IntegerToRoman
{

    class IntegerToRoman
    {
        private IDictionary<int, string> digits = new Dictionary<int, string>
        {
            {1, "I"},
            {2, "II"},
            {3, "III"},
            {4, "IV"},
            {5, "V"},
            {6, "VI"},
            {7, "VII"},
            {8, "VIII"},
            {9, "IX"},
        };

        private IDictionary<int, string> tens = new Dictionary<int, string>
        {
            {1, "X"},
            {2, "XX"},
            {3, "XXX"},
            {4, "XL"},
            {5, "L"},
            {6, "LX"},
            {7, "LXX"},
            {8, "LXXX"},
            {9, "XC"}
        };

        private IDictionary<int, string> hundreds = new Dictionary<int, string>
        {
            {1, "C"},
            {2, "CC"},
            {3, "CCC"},
            {4, "CD"},
            {5, "D"},
            {6, "DC"},
            {7, "DCC"},
            {8, "DCCC"},
            {9, "CM"}
        };

        private IDictionary<int, string> thousands = new Dictionary<int, string>
        {
            {1, "M"},
            {2, "MM"},
            {3, "MMM"},
        };

        public string IntToRoman(int num)
        {
            var roman = "";
            var thousand = num / 1000;
            if (thousand > 0)
            {
                roman += thousands[thousand];
                num -= 1000 * thousand;
            }

            var hundred = num / 100;
            if (hundred > 0)
            {
                num -= 100 * hundred;
                roman += hundreds[hundred];
            }

            var ten = num / 10;
            if (ten > 0)
            {
                num -= 10 * ten;
                roman += tens[ten];
            }

            if (num > 0)
                roman += digits[num];

            return roman;
        }
    }
}
