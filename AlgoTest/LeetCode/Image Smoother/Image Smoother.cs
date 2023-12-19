namespace AlgoTest.LeetCode.Image_Smoother;

public class Image_Smoother
{
    public int[][] ImageSmoother(int[][] img) {
        
        var dx = new int[] { -1, -1, -1, 0, 0, 1, 1, 1};
        var dy = new int[] { -1,  0,  1, -1, 1,-1, 0, 1};
        
        var m = img.Length;
        var n = img[0].Length;
        
        var output = new int[m][];
        for(var i = 0; i < m; i++)
            output[i] = new int[n];
                
        var sum = 0; 
        var count = 0;
        for(var i = 0; i < m; i++)
        {
            for(var j = 0; j < n; j++)
            {
                sum = img[i][j];
                count = 1;
                
                for(var k = 0; k < 8; k++)
                {
                    var r = i + dx[k];
                    var c = j + dy[k];
                    
                    if(r >= 0 && r < m && c >= 0 && c < n)
                    {
                        sum += img[r][c];
                        count++;
                    }
                }
                output[i][j] = sum/count;
            }
        }
        return output;
    }
}