using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximize_Number_of_Nice_Divisors;

public class Maximize_Number_of_Nice_Divisors
{
    private Dictionary<long, long> _lookup;
    
    public int MaxNiceDivisors(int primeFactors) {
        _lookup = new Dictionary<long, long>();
        _lookup.Add(0, 1);
        _lookup.Add(1, 3);
        
        switch (primeFactors)
        {
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 3;
        }

        var mod = primeFactors % 3;
        return mod switch
        {
            1 => (int)((ThreePower((primeFactors - 4) / 3) * 4) % 1000000007),
            2 => (int)((ThreePower((primeFactors - 2) / 3) * 2) % 1000000007),
            _ => (int)(ThreePower(primeFactors / 3))
        };
    }
    
    private long ThreePower(long n)
    {
        if (_lookup.ContainsKey(n))
            return _lookup[n];
        
        var res = (ThreePower(n / 2) * ThreePower(n - n / 2)) % 1000000007;
        _lookup.Add(n, res);
        return res;
    }
}