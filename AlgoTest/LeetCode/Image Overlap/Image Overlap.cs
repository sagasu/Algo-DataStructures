public class Solution {
    public int LargestOverlap(int[][] img1, int[][] img2) 
{
    var first = new HashSet<int>();
    var second = new HashSet<int>();
    int n = img1.Length;
    for(var i = 0; i < n; ++i)
    {
        for(var j = 0; j < n; ++j)
        {
            if(img1[i][j] == 1)
            {
                first.Add((i + 1000*j));
            }
            
            if(img2[i][j] == 1)
            {
                second.Add((i + 1000*j));
            }
        }
    }
    
    var result = 0;
    for(int i = -n-1; i <= n+1; ++i)
    {
        for(int j = -n-1; j <= n+1; ++j)
        {
            var temp = 0; 
            foreach(var candidate in first)
            {
                if(second.Contains(candidate + i + j*1000))
                {
                    ++temp;
                }
            }
            result = Math.Max(result, temp);
            
        }
    }
    
    return result;
}
}