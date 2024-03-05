namespace AlgoTest.LeetCode.Minimum_Length_of_String_After_Deleting_Similar_Ends;

public class Minimum_Length_of_String_After_Deleting_Similar_Ends
{
    public int MinimumLength(string s) {
        int st=0,end=s.Length-1;
        
        while(st<end)
        {
            if(s[st]!=s[end]) break;
            var nst=st+1;
            
            while(nst<end&&s[nst]==s[st])
                nst++;
            
            var nend=end-1;
            while(nst<nend&&s[nend]==s[end])
                nend--;
            
            st=nst;
            end=nend;
        }
        
        return end-st+1;
    }
}