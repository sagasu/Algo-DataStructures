using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Coupon_Code_Validator;

public class Coupon_Code_Validator
{
    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive) => code.
        Where(m => !string.IsNullOrEmpty(m)).
        Select((m, i) => (m, i)).
        Where(m => isActive[m.i]).
        Where(m => ((string[])["electronics", "grocery", "pharmacy", "restaurant"]).Contains(businessLine[m.i])).
        Where(m => !m.m.ToCharArray().Any(n => !char.IsLetterOrDigit(n) && n != '_')).
        OrderBy(m => businessLine[m.i]).
        ThenBy(m => m.m, StringComparer.Ordinal).
        Select(m => m.m).
        ToList();
}