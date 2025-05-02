namespace AlgoTest.LeetCode.Push_Dominoes;

public class Push_Dominoes
{
    public string PushDominoes(string dominoes) {
        if(dominoes.Length==1) return dominoes;

        var ca=dominoes.ToCharArray();
        
        for(;;) {
            bool doneSomething=false;
            
            char prev='.', curr=ca[0], next=ca[1];
            for(int i=0; i<ca.Length; i++) {
                if(curr=='.') {
                    bool left=next=='L';
                    if(prev=='R') {
                        if(!left) { ca[i]='R'; doneSomething=true; }
                    } else if(left) { ca[i]='L'; doneSomething=true; }
                }
                prev=curr; curr=next; next=i+2<ca.Length ? ca[i+2] : '.';
            }

            if(!doneSomething) return new string(ca);
        }
    }
}