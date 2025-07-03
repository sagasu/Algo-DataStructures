using System.Text;

namespace AlgoTest.LeetCode.Find_the_K_th_Character_in_String_Game_I;

public class Find_the_K_th_Character_in_String_Game_I
{
    public char KthCharacter(int k) {
        StringBuilder s = new StringBuilder();
        StringBuilder s1 = new StringBuilder();
        s.Append('a');
        do{
            s1.Clear();
            for(int i= 0;i<s.Length;i++)
            { 
                s1.Append((char)((int)s[i]+1)); 
            }
            s.Append(s1);
        }while(s.Length<=k);
        return s[k-1];
    }
}