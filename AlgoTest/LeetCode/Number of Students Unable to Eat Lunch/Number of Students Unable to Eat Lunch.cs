using System;
using System.Linq;

namespace AlgoTest.LeetCode.Number_of_Students_Unable_to_Eat_Lunch;

public class Number_of_Students_Unable_to_Eat_Lunch
{
    public int CountStudents(int[] students, int[] sandwiches) =>
        new Func<int[], int>(counts =>
            sandwiches.Length -
            sandwiches
                .TakeWhile(sanwich => counts[sanwich]-- > 0)
                .Count()
        )(new[] {
            students.Count(student => student == 0),
            students.Count(student => student == 1),
        });
}