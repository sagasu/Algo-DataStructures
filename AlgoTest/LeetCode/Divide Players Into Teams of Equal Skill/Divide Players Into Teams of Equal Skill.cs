using System;

namespace AlgoTest.LeetCode.Divide_Players_Into_Teams_of_Equal_Skill;

public class Divide_Players_Into_Teams_of_Equal_Skill
{
    public long DividePlayers(int[] skill) 
    {
        long result = 0;
        Array.Sort(skill);
        var n = skill.Length;
        var twoSum = skill[0] + skill[n - 1];

        for (var i = 0; i < n/2; i++)
        {
            if (skill[i] + skill[n - 1 - i] != twoSum)
                return -1;
            
            result += skill[i] * skill[n - 1 - i];
        }
        return result;
    }
}