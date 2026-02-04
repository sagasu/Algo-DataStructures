using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Trionic_Array_II;

public class Trionic_Array_II
{
    private static readonly int SlopeTypeIncreasing = 1;
    private static readonly int SlopeTypeDecreasing = -1;
    private static readonly int SlopeTypeHorizontal = 0;
    private static readonly int PlaceholderValue = 0;

    public long MaxSumTrionic(int[] InputNumbers)
    {
        List<long[]> SlopeSegments = GenerateSlopeData(InputNumbers);
        return FindMaxTrionicSum(SlopeSegments);
    }

    private long FindMaxTrionicSum(List<long[]> SlopeSegments)
    {
        long MaxTotalSum = long.MinValue;
        int FrontIndex = 2;
        int BackIndex = 0;

        if (IsTrionicPattern(BackIndex, FrontIndex, SlopeSegments))
            MaxTotalSum = Math.Max(MaxTotalSum, CalculateTrionicSum(BackIndex, FrontIndex, SlopeSegments));

        ++FrontIndex;
        ++BackIndex;

        while (FrontIndex < SlopeSegments.Count)
        {
            if (IsTrionicPattern(BackIndex, FrontIndex, SlopeSegments))
                MaxTotalSum = Math.Max(MaxTotalSum, CalculateTrionicSum(BackIndex, FrontIndex, SlopeSegments));
            
            ++FrontIndex;
            ++BackIndex;
        }
        return MaxTotalSum;
    }

    private long CalculateTrionicSum(int BackIndex, int FrontIndex, List<long[]> SlopeSegments)
    {
        long CurrentSum = 0;
        CurrentSum += SlopeSegments[BackIndex][0];
        CurrentSum += SlopeSegments[BackIndex + 1][0];
        CurrentSum += SlopeSegments[FrontIndex][1];
        return CurrentSum;
    }

    private bool IsTrionicPattern(int BackIndex, int FrontIndex, List<long[]> SlopeSegments)
    {
        return SlopeSegments[BackIndex][2] == SlopeTypeIncreasing
                && SlopeSegments[BackIndex + 1][2] == SlopeTypeDecreasing
                && SlopeSegments[FrontIndex][2] == SlopeTypeIncreasing;
    }

    public List<long[]> GenerateSlopeData(int[] InputNumbers)
    {
        List<long[]> SlopeSegments = new List<long[]>();
        int CurrentIndex = 0;

        while (CurrentIndex < InputNumbers.Length - 1)
        {
            CurrentIndex = ProcessAscendingSequence(SlopeSegments, InputNumbers, CurrentIndex);
            CurrentIndex = ProcessDescendingSequence(SlopeSegments, InputNumbers, CurrentIndex);
            CurrentIndex = ProcessFlatSequence(SlopeSegments, InputNumbers, CurrentIndex);
        }
        return SlopeSegments;
    }

    private int ProcessAscendingSequence(List<long[]> SlopeSegments, int[] InputNumbers, int CurrentIndex)
    {
        long MaxEndingSum = 0;
        long FirstPairSum = 0;
        long TotalAscendingSum = 0;
        bool IsAscendingFound = false;

        while (CurrentIndex < InputNumbers.Length - 1 && InputNumbers[CurrentIndex] < InputNumbers[CurrentIndex + 1])
        {
            TotalAscendingSum += InputNumbers[CurrentIndex];

            if (InputNumbers[CurrentIndex] < 0)
                MaxEndingSum = InputNumbers[CurrentIndex];
            else
                MaxEndingSum = Math.Max(MaxEndingSum, 0) + InputNumbers[CurrentIndex];

            if (!IsAscendingFound)
                FirstPairSum = InputNumbers[CurrentIndex] + InputNumbers[CurrentIndex + 1];

            ++CurrentIndex;
            IsAscendingFound = true;
        }

        if (IsAscendingFound)
        {
            long SegmentStartScore = MaxEndingSum + InputNumbers[CurrentIndex];
            long SegmentEndScore = Math.Max(TotalAscendingSum + InputNumbers[CurrentIndex], FirstPairSum);
            SlopeSegments.Add(new long[] { SegmentStartScore, SegmentEndScore, SlopeTypeIncreasing });
        }

        return CurrentIndex;
    }

    private int ProcessDescendingSequence(List<long[]> SlopeSegments, int[] InputNumbers, int CurrentIndex)
    {
        long CurrentDescendingSum = 0;
        int PeakValue = InputNumbers[CurrentIndex];
        bool IsDescendingFound = false;

        while (CurrentIndex < InputNumbers.Length - 1 && InputNumbers[CurrentIndex] > InputNumbers[CurrentIndex + 1])
        {
            CurrentDescendingSum += InputNumbers[CurrentIndex];
            IsDescendingFound = true;
            ++CurrentIndex;
        }

        if (IsDescendingFound)
            SlopeSegments.Add(new long[] { CurrentDescendingSum - PeakValue, PlaceholderValue, SlopeTypeDecreasing });
        
        return CurrentIndex;
    }

    private int ProcessFlatSequence(List<long[]> SlopeSegments, int[] InputNumbers, int CurrentIndex)
    {
        bool IsFlatFound = false;
        while (CurrentIndex < InputNumbers.Length - 1 && InputNumbers[CurrentIndex] == InputNumbers[CurrentIndex + 1])
        {
            IsFlatFound = true;
            ++CurrentIndex;
        }

        if (IsFlatFound)
            SlopeSegments.Add(new long[] { PlaceholderValue, PlaceholderValue, SlopeTypeHorizontal });
        
        return CurrentIndex;
    }
}