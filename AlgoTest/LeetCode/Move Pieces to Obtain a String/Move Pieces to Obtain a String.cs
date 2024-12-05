namespace AlgoTest.LeetCode.Move_Pieces_to_Obtain_a_String;

public class Move_Pieces_to_Obtain_a_String
{
    public bool CanChange(string start, string target) {
        int l = 0, r = 0, n = start.Length;
        while(l < n || r < n){
            while(l < n && start[l] == '_')l++;
            while(r < n && target[r] == '_')r++;
            if(l == n || r == n)break;
            if( start[l] != target[r] || 
                (l > r && start[l] == 'R') || (r > l && start[l] == 'L')) 
                return false;
            l++;
            r++;
        }
        while(l < n && start[l] == '_')l++;
        while(r < n && target[r] == '_')r++;
        return l == n && r == n;
    }
}