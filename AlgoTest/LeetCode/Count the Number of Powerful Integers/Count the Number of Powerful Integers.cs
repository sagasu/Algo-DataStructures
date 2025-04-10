using System;

namespace AlgoTest.LeetCode.Count_the_Number_of_Powerful_Integers;

public class Count_the_Number_of_Powerful_Integers
{
    private long getFirstPowerfulInt(long start, int limit, string s)
    {
        long sNumber = long.Parse(s);
        long mod = (long)Math.Pow(10, s.Length),
            zeroMod = 1;
        long startCarries = (start / mod);
        if (startCarries * mod + sNumber < start)
        {
            startCarries++;
        }
        
        mod = 1;
        while (startCarries * 10 > mod)
        {
            int digit = (int)(startCarries / mod % 10);
            if (digit > limit)
            {
                startCarries += (10 - digit) * mod;
                zeroMod = mod;
            }
            mod *= 10;
        }
        startCarries = (startCarries / zeroMod) * zeroMod;

        return startCarries * (long)Math.Pow(10, s.Length) + sNumber;
    }

    private long getLastPowerfulInt(long finish, int limit, string s)
    {
        long sNumber = long.Parse(s);
        long mod = (long)Math.Pow(10, s.Length);
        long finishCarries = (finish / mod);
        bool switchToLimit = false;
        if (finishCarries * mod + sNumber > finish)
        {
            finishCarries--;
        }

        mod = 1;
        while (finishCarries > mod * 10)
        {
            mod *= 10;
        }

        while (mod > 0)
        {
            int digit = (int)(finishCarries / mod % 10);
            if (switchToLimit)
            {
                finishCarries -= (digit - limit) * mod;
            }
            else if (digit > limit)
            {
                finishCarries -= (digit - limit) * mod;
                switchToLimit = true;
            }
            mod /= 10;
        }

        return finishCarries * (long)Math.Pow(10, s.Length) + sNumber;
    }

    public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
    {
        long startNumber = getFirstPowerfulInt(start, limit, s);
        if (startNumber > finish)
        {
            return 0;
        }

        long lastNumber = getLastPowerfulInt(finish, limit, s);
        if (lastNumber < startNumber)
        {
            return 0;
        }
        long mod = (long)Math.Pow(10, s.Length);
        long startCarries = (startNumber / mod),
            lastCarries = (lastNumber / mod);
        long ans = 1;
        mod = 1;

        while (startCarries < lastCarries)
        {
            int startDigit = (int)(startCarries % 10);
            int lastDigit = (int)(lastCarries % 10);

            if (startDigit > limit)
            {
                startCarries += (10 - startDigit);
            }
            if (startDigit > lastDigit)
            {
                // (startDigit to limit) + (0 to lastDigit)
                ans += (lastDigit + (limit - startDigit) + 1) * mod;
                startCarries += lastDigit + (10 - startDigit) + 1;
            }
            else if (startDigit < lastDigit)
            {
                ans += (lastDigit - startDigit) * mod;
                startCarries += (lastDigit - startDigit);
            }
            mod *= (limit + 1); // 0 to limit
            startCarries /= 10;
            lastCarries /= 10;
        }

        return ans;
    }
}