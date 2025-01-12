using System.Collections.Generic;

namespace AlgoTest.LeetCode.Check_if_a_Parentheses_String_Can_Be_Valid;

public class Check_if_a_Parentheses_String_Can_Be_Valid
{
    public bool CanBeValid(string s, string locked) {
        if (s.Length % 2 == 1)
            return false;
        var lockedOpened = new Stack<int>();
        var unlocked = new Stack<int>();
        for(int i = 0; i < s.Length; i++)
        {
            if (locked[i] == '0')
            {
                unlocked.Push(i);
            }
            else
            {
                if (s[i] == '(')
                    lockedOpened.Push(i);
                else
                {
                    if (lockedOpened.Count > 0) lockedOpened.Pop();
                    else if(unlocked.Count > 0) unlocked.Pop();
                    else return false;
                }
            }
        }
        while(lockedOpened.Count > 0)
        {
            if (unlocked.Count > 0 && unlocked.Peek() > lockedOpened.Peek())
            {
                unlocked.Pop();
                lockedOpened.Pop();
            }
            else
                return false;
        }
        return unlocked.Count % 2 == 0;
    }
}