using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Fraction_to_Recurring_Decimal;

public class Fraction_to_Recurring_Decimal
{
    public string FractionToDecimal(int numerator, int denominator) {
        if (numerator == 0) return "0";

        StringBuilder fraction = new();
        if (numerator < 0 ^ denominator < 0) fraction.Append("-");

        var dividend = Math.Abs((long)numerator);
        var divisor = Math.Abs((long)denominator);

        fraction.Append((dividend / divisor).ToString());

        var remainder = dividend % divisor;
        if (remainder == 0) return fraction.ToString();

        fraction.Append(".");

        Dictionary<long, int> map = new();
        while (remainder != 0) {
            if (map.TryGetValue(remainder, out var value)) {
                fraction.Insert(value, "(");
                fraction.Append(")");
                break;
            }
            
            map[remainder] = fraction.Length;
            remainder *= 10;
            fraction.Append((remainder / divisor).ToString());
            remainder %= divisor;
        }

        return fraction.ToString();
    }
}