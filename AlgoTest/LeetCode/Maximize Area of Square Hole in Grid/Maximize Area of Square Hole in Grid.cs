using System;

namespace AlgoTest.LeetCode.Maximize_Area_of_Square_Hole_in_Grid;

public class Maximize_Area_of_Square_Hole_in_Grid
{
    public int MaximizeSquareHoleArea(int GridHeight, int GridWidth, int[] HorizontalBars, int[] VerticalBars)
    {
        Array.Sort(HorizontalBars);
        Array.Sort(VerticalBars);

        int MaxHorizontalConsecutive = 1;
        int MaxVerticalConsecutive = 1;
        int CurrentHorizontalConsecutive = 1;
        int CurrentVerticalConsecutive = 1;

        for (int Index = 1; Index < HorizontalBars.Length; Index++)
        {
            if (HorizontalBars[Index] == HorizontalBars[Index - 1] + 1)
            {
                CurrentHorizontalConsecutive++;
            }
            else
            {
                CurrentHorizontalConsecutive = 1;
            }

            MaxHorizontalConsecutive = Math.Max(MaxHorizontalConsecutive, CurrentHorizontalConsecutive);
        }

        for (int Index = 1; Index < VerticalBars.Length; Index++)
        {
            if (VerticalBars[Index] == VerticalBars[Index - 1] + 1)
            {
                CurrentVerticalConsecutive++;
            }
            else
            {
                CurrentVerticalConsecutive = 1;
            }

            MaxVerticalConsecutive = Math.Max(MaxVerticalConsecutive, CurrentVerticalConsecutive);
        }

        int SquareSideLength = Math.Min(MaxHorizontalConsecutive, MaxVerticalConsecutive) + 1;
        return SquareSideLength * SquareSideLength;
    }
}