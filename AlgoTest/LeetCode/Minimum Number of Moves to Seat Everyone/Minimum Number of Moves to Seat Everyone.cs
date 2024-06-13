using System;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Number_of_Moves_to_Seat_Everyone;

public class Minimum_Number_of_Moves_to_Seat_Everyone
{
    public int MinMovesToSeat(int[] A, int[] B) => A
        .Order()
        .Zip(B.Order(), (x, y) => Math.Abs(x - y))
        .Sum();
}