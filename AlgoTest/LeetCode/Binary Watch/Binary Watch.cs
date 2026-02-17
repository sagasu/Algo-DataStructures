using System.Collections.Generic;

namespace AlgoTest.LeetCode.Binary_Watch;

public class Binary_Watch
{
    public IList<string> ReadBinaryWatch(int TurnedOn)
    {
        IList<string> ValidTimes = new List<string>();
        for (int Hour = 0; Hour < 12; ++Hour)
        {
            for (int Minute = 0; Minute < 60; ++Minute)
            {
                if (CalculateBitCount(Hour) + CalculateBitCount(Minute) == TurnedOn)
                    ValidTimes.Add(Hour + ":" + (Minute < 10 ? "0" : "") + Minute);
            }
        }
        return ValidTimes;
    }

    private static int CalculateBitCount(int Value)
    {
        Value = Value - ((Value >> 1) & 0x55555555);
        Value = (Value & 0x33333333) + ((Value >> 2) & 0x33333333);
        Value = (Value + (Value >> 4)) & 0x0f0f0f0f;
        Value = Value + (Value >> 8);
        Value = Value + (Value >> 16);
        return Value & 0x3f;
    }
}